using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Project")]
  public  class Project
    {
        public Project()
        {
            Id = Guid.NewGuid();
            Creators = new HashSet<ApplicationUser>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [DataType(DataType.Url)]
        public string URL { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApplicationUser> Creators { get; set; }
    }
}
