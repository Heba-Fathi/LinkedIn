using Linkedin.Entites.Enum;
using Linkedin.Models.Entites;
using Linkedin.Models.Enum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            WorkExperiences = new HashSet<WorkExperience>();
            Skills = new HashSet<Skill>();
            Comments = new HashSet<Comment>();
            LikedComments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            LikedPosts = new HashSet<Post>();
            Awards = new HashSet<Award>();
            VolunteerExperiences = new HashSet<VolunteerExperience>();
            Projects= new HashSet<Project>();
            Patents = new HashSet<Patent>();
            Languages = new HashSet<Language>();
            Courses = new HashSet<Course>();
            EducationExperiences= new HashSet<EducationExperience>();
            Publications = new HashSet<Publication>();
            TestScores= new HashSet<TestScore>();
            Connections = new HashSet<ApplicationUser>();
            Requests = new HashSet<ApplicationUser>();

        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Country Country { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTime? BirthDay { get; set; }
        public string HeadLine { get; set; }
        public Gender Gender{ get; set; }
        public Indstry Indstry { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ProfilePicURL { get; set; }
        [DataType(DataType.ImageUrl)]
        public string CoverPicURL { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        public virtual ICollection<Post> Posts{ get; set; }
        public virtual ICollection<Post> LikedPosts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Comment> LikedComments { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<TestScore> TestScores { get; set; }
        public virtual ICollection<Patent> Patents { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<EducationExperience> EducationExperiences { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<VolunteerExperience> VolunteerExperiences { get; set; }
        public virtual ICollection<ApplicationUser> Connections { get; set; }
        public virtual ICollection<ApplicationUser> Requests { get; set; }





        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
