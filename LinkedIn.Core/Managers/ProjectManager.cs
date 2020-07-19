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
    public class ProjectManager : Repository<Project, ApplicationDbContext>
    {
        public ProjectManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
