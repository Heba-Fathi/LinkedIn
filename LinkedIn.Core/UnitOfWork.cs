using Linkedin.DbContext;
using LinkedIn.Core.Managers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Core
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext context;
        public UnitOfWork(IOwinContext owinContext)
        {
            context = owinContext.Get<ApplicationDbContext>();
            ApplicationUserManager = owinContext.Get<ApplicationUserManager>();
            ApplicationSignInManager = owinContext.Get<ApplicationSignInManager>();
        }
        public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> options, IOwinContext owinContext)
        {
            return new UnitOfWork(owinContext);
        }

        public ApplicationUserManager ApplicationUserManager { get; }
        public ApplicationSignInManager ApplicationSignInManager { get; }
        public AwardManager AwardManager
        {
            get
            {
                return new AwardManager(context);
            }
        }

        public CommentManager CommentManager
        {
            get
            {
                return new CommentManager(context);
            }
        }
        public CourseManager CourseManager
        {
            get
            {
                return new CourseManager(context);
            }
        }
        public EducationExperienceManager EducationExperienceManager
        {
            get
            {
                return new EducationExperienceManager(context);
            }
        }
        public LanguageManager LanguageManager
        {
            get
            {
                return new LanguageManager(context);
            }
        }
        public PatentManager PatentManager
        {
            get
            {
                return new PatentManager(context);
            }
        }

        public PostManager PostManager
        {
            get
            {
                return new PostManager(context);
            }
        }
        public ProjectManager ProjectManager
        {
            get
            {
                return new ProjectManager(context);
            }
        }
        public PublicationManager PublicationManager
        {
            get
            {
                return new PublicationManager(context);
            }
        }
        public SavedPlaceManager SavedPlaceManager
        {
            get
            {
                return new SavedPlaceManager(context);
            }
        }
        public SkillManager SkillManager
        {
            get
            {
                return new SkillManager(context);
            }
        }

        public TestScoreManager TestScoreManager
        {
            get
            {
                return new TestScoreManager(context);
            }
        }

        public VolunteerExperienceManager VolunteerExperienceManager
        {
            get
            {
                return new VolunteerExperienceManager(context);
            }
        }

        public WorkExperienceManager WorkExperienceManager
        {
            get
            {
                return new WorkExperienceManager(context);
            }
        }

        public void Dispose()
        {
            //WorkExperienceManager = null;
            //SavedPlaceManager = null;
        }
    }
}
