using Linkedin.Models.Entites;
using LinkedIn.Core;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    public class HomeController : Controller
    {

        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search(string fname, string lname)
        {
            var user = UnitOfWork.ApplicationUserManager;
            List<ApplicationUser> listOfUsers = user.Users.Where(e => (fname.Length > 0 && e.FirstName.Contains(fname))
                                                                    ||(lname.Length > 0 && e.LastName.Contains(lname))).ToList();

            return View(listOfUsers);
        }
    }
}