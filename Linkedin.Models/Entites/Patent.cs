using Linkedin.Entites.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Patent")]
    public class Patent
    {
        public Patent()
        {
            Inventors = new HashSet<ApplicationUser>();
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Title{ get; set; }
        [Required]
        public Country Office{ get; set; }
        public DateTime? Date { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public bool Issued { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApplicationUser> Inventors { get; set; }
    }
}
