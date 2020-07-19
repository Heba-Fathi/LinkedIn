using Linkedin.Models.Entites;
using LinkedIn.Core.Managers;
using LinkedIn.Web.Models.CustomValidators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
    public class PostViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        [DataType(DataType.ImageUrl)]
        [ImgValidation("JPG,JPEG,PNG")]
        public IEnumerable<HttpPostedFileBase> imgFile { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<ApplicationUser> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Guid? SharedPostId { get; set; }
        public virtual Post SharedPost { get; set; }
        public virtual ICollection<Post> PostsSharedMe { get; set; }
        public DateTime Date { get; set; }
        public List<Post> PagePosts{ get; set; }

        public ApplicationUser User { get; set; }
        public PostViewModel()
        {
            User= HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            PagePosts = new List<Post>();
        }
    }
}