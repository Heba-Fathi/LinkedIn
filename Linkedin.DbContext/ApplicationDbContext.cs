using Linkedin.DbContext.Configs;
using Linkedin.Models;
using Linkedin.Models.Entites;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public  DbSet<Award> Awards{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<EducationExperience> EducationExperiences{ get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Patent> Patents { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<SavedPlace> SavedPlaces { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TestScore> TestScores { get; set; }
        public DbSet<VolunteerExperience> VolunteerExperiences { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
