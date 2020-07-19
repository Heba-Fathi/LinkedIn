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
    [Table("EducationExperience")]
    public class EducationExperience
    {
        public EducationExperience()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Grade { get; set; }
        public Degree? Degree { get; set; }
        public string Description { get; set; }
        public string Activites { get; set; }
        public DateTime? StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        [ForeignKey("School")]
        [Required]
        public Guid SchoolId { get; set; }
        public virtual SavedPlace School { get; set; }
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
