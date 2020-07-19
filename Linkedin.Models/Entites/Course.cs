using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Course")]
    public class Course
    {
        public Course()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Number { get; set; }
        [ForeignKey("User")]
        [Required]

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
