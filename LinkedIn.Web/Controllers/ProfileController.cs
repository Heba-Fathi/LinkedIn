using Linkedin.Models.Entites;
using Linkedin.Models.Enum;
using LinkedIn.Core;
using LinkedIn.Core.Managers;
using LinkedIn.Web.Models;
using LinkedIn.Web.Models.ProfileViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    public class ProfileController : Controller
    {
        //var CurrentUser;
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }
        public ProfileController()
        {
            System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
        // GET: Profile
        public ActionResult Index(string id)
        {
            ApplicationUser user;
            var userManager = UnitOfWork.ApplicationUserManager;
            var connections = userManager.GetAllConnections(User.Identity.GetUserId());
            var requests = userManager.GetRequestUsers(User.Identity.GetUserId());
            if (id == null)
            {
                user = UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
            }
            else
            {
                user = UnitOfWork.ApplicationUserManager.FindById(id);
            }
            UserSearchViewModel userVM = new UserSearchViewModel();
            if (connections.Contains(user))
            {
                userVM.User = user;
                userVM.UserType = UserType.Connected;
            }
            else if (user.Requests.Contains(user))
            {
                userVM.User = user;
                userVM.UserType = UserType.requested;
            }
            else if (requests.Contains(user))
            {
                userVM.User = user;
                userVM.UserType = UserType.pending;
            }
            else
            {
                userVM.User = user;
                userVM.UserType = UserType.noConnection;
            }
            return View(userVM);
        }

        [HttpGet]
        public JsonResult GetWorkExp(Guid id)
        {
            WorkExperience workExp = UnitOfWork.WorkExperienceManager.GetById(id);
            int endMonth = 0, endYear = 0;
            if(workExp.EndDate != null)
            {
                endMonth = workExp.EndDate.Value.Month;
                endYear = workExp.EndDate.Value.Year;
            }
            return Json(new
            {
                Title = workExp.Title,
                EmploymentType = workExp.EmploymentType,
                Location = workExp.Location,
                Description = workExp.Description,
                StartMonth = workExp.StartDate.Month,
                StartYear = workExp.StartDate.Year,
               // EndMonth =endMonth,
                //EndYear = endYear,
                IsPresent = workExp.IsPresent
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperienceViewModel workExpVM)
        {
            if (ModelState.IsValid)
            {
                workExpVM.Company.PlaceType = PlaceType.Company;
                UnitOfWork.SavedPlaceManager.Add(workExpVM.Company);
                WorkExperience workExp = new WorkExperience {
                                                            UserId = User.Identity.GetUserId(),
                                                            Title = workExpVM.Title,
                                                            Location = workExpVM.Location,
                                                            Description = workExpVM.Description,
                                                            EmploymentType = workExpVM.EmploymentType,
                                                            CompanyId = workExpVM.Company.Id,
                                                            StartDate = new DateTime(workExpVM.StartYear, workExpVM.StartMonth, 1)
                                                            };
                if(workExpVM.EndMonth != null && workExpVM.EndYear != null)
                {
                    workExp.EndDate = new DateTime((int)workExpVM.EndYear, (int)workExpVM.EndMonth, 1);
                }
                
                UnitOfWork.WorkExperienceManager.Add(workExp);
                return PartialView("__AddExperienceCard", workExp);
            }
           
            return View("Index");
        }

        [HttpGet]
        public ActionResult EditWorkExperience(Guid id)
        {
            WorkExperience wExp = UnitOfWork.WorkExperienceManager.GetById(id);
          
            WorkExperienceViewModel wExpVM = new WorkExperienceViewModel
            {
                //  UserId = User.Identity.GetUserId(),
                Title = wExp.Title,
                Location = wExp.Location,
                Description = wExp.Description,
                EmploymentType = wExp.EmploymentType,
                // CompanyId = wExp.Company.Id,
                //  StartDate = new DateTime(wExp.StartYear, wExp.StartMonth, 1)

            };
            return PartialView("_Experience",wExpVM);

        }
        [HttpPost]
        public ActionResult EditWorkExperience(WorkExperience wExp)
        {
            UnitOfWork.WorkExperienceManager.Update(wExp);
            ApplicationUser user = UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
            return RedirectToAction("index", user);

        }
        public ActionResult DeleteExperience(string expId)
        {
            Guid id = Guid.Parse(expId);
            var w = UnitOfWork.WorkExperienceManager.GetAll();
            WorkExperience wExp = w.FirstOrDefault(x => x.Id == id);
            UnitOfWork.WorkExperienceManager.Delete(wExp);
            return RedirectToAction("index");
        }
     
    }
}