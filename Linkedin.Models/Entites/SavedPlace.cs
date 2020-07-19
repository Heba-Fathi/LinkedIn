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
    [Table("SavedPlace")]
    public class SavedPlace
    {
        public SavedPlace()
        {
            Id = Guid.NewGuid();
            EducationExperiences = new HashSet<EducationExperience>();
            WorkExperiences = new HashSet<WorkExperience>();
            VolunteerExperiences = new HashSet<VolunteerExperience>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PlaceType PlaceType { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public virtual ICollection<EducationExperience> EducationExperiences { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        public virtual ICollection<VolunteerExperience> VolunteerExperiences { get; set; }
    }
}
