using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Award")]
   public class Award
    {
        public Award()
        {
            Id = Guid.NewGuid(); 
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Issuer { get; set; }
        public DateTime? DateTime { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
