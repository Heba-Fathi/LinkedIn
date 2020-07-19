using Linkedin.DbContext;
using Linkedin.Models.Entites;
using LinkedIn.Core;
using LinkedIn.Core.Managers;
using LinkedIn.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    [Authorize]

    public class NewsFeedController : Controller
    {


        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }

        //public ApplicationUser loginuser
        //{
        //    get
        //    {
        //        return UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
        //    }
        //}

        // GET: NewsFeed
        [HttpGet]
        public ActionResult Index()
        {
            List<Post> darft = new List<Post>();
            var userManager = UnitOfWork.ApplicationUserManager;
            PostViewModel postVM = new PostViewModel();
            if (postVM.User.Posts != null)
            {
                foreach (var post in postVM.User.Posts)
                {
                    post.Comments = post.Comments.OrderBy(d => Convert.ToDateTime(d.Date)).ToList();
                }
                darft.AddRange(postVM.User.Posts);
            }

            foreach (var item in userManager.GetAllConnections(User.Identity.GetUserId().ToString()))
            {
                foreach (var post in item.Posts)
                {
                    post.Comments = post.Comments.OrderBy(d => Convert.ToDateTime(d.Date)).ToList();
                }
                darft.AddRange(item.Posts);
            }
            //postVM.PagePosts.OrderBy(e => e.Date.Year)
            //    .ThenBy(e => e.Date.Month)
            //    .ThenBy(e => e.Date.Day)
            //    .ThenBy(e => e.Date.TimeOfDay.Hours)
            //    .ThenBy(e => e.Date.TimeOfDay.Minutes)
            //    .ThenBy(e => e.Date.TimeOfDay.Seconds);
            postVM.PagePosts = darft.OrderByDescending(d => Convert.ToDateTime(d.Date)).ToList();
            return View(postVM);
        }

        [HttpPost]
        public ActionResult AddPost(Post post, HttpPostedFileBase imgFile)
        {
            var userManager = UnitOfWork.ApplicationUserManager;
            var postManager = UnitOfWork.PostManager;

            if (ModelState.IsValid && (post.Status != null || imgFile != null))
            {
                if (imgFile != null)
                {
                    string extension = System.IO.Path.GetExtension(imgFile.FileName);
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(imgFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = "~/SavedImages/" + fileName;
                    imgFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/SavedImages"), fileName));
                    post.ImageUrl = path;
                }
                post.AuthorId = User.Identity.GetUserId();
                post.Date = DateTime.Now;
                postManager.Add(post);
                post.Author = userManager.FindById(User.Identity.GetUserId());
                ModelState.Clear();
                return PartialView("_PostBody", post);
            }

            PostViewModel postVM = new PostViewModel();
            return View("Index", postVM);
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel commentVM)
        {
            if(commentVM.Content.Length > 0)
            {
                string userId = User.Identity.GetUserId();
                var user = UnitOfWork.ApplicationUserManager.FindById(userId);
                Comment comment = new Comment
                                  {
                                        Content = commentVM.Content,
                                        Date = DateTime.Now,
                                        PostId = commentVM.PostId,
                                        AuthorId = userId
                                   };


                UnitOfWork.CommentManager.Add(comment);
                return PartialView("_Comment", comment);
            }
            return null;
            //return Json(new
            //{
            //    AuthorName = (user.FirstName + " " + user.LastName),
            //    CommentContent = CommentContent,
            //    Date = DateTime.Now
            //}, JsonRequestBehavior.AllowGet);
        }
    
    [HttpGet]
    public ActionResult Like(string postId)
    {
        var posts = UnitOfWork.PostManager.GetAll();
        Guid id = Guid.Parse(postId);
        var post = posts.FirstOrDefault(p => p.Id == id);
        ApplicationUser user = UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
        post.Likes.Add(user);
        UnitOfWork.PostManager.Update(post);
        return RedirectToAction("index", user);
    }
        
               [HttpGet]
    public ActionResult LikeComment(string commId)
        {
            var comments = UnitOfWork.CommentManager.GetAll();
            Guid id = Guid.Parse(commId);
            var comment = comments.FirstOrDefault(p => p.Id == id);
            ApplicationUser user = UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
            comment.Likes.Add(user);
            UnitOfWork.CommentManager.Update(comment);
            return RedirectToAction("index", user);
        }
    }


} 

