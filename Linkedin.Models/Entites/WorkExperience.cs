using Linkedin.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("WorkExperience")]
    public class WorkExperience
    {
        public WorkExperience()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public EmploymentType EmploymentType { get; set; }
        [ForeignKey("Company")]
        [Required]
        public Guid CompanyId { get; set; }
        public virtual SavedPlace Company { get; set; }
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User{ get; set; }
        public string Location { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPresent { get; set; }


    }
}
