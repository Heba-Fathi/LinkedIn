using Linkedin.DbContext;
using Linkedin.Models.Entites;
using LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Core.Managers
{
    public class CourseManager : Repository<Course, ApplicationDbContext>
    {
        public CourseManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
