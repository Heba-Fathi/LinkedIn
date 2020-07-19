using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Publication")]
    public class Publication
    {
        public Publication()
        {
            Authors = new HashSet<ApplicationUser>();
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? Date { get; set; }

        [ForeignKey("Publisher")]
        public Guid? PublisherId { get; set; }
        public virtual SavedPlace Publisher { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApplicationUser> Authors { get; set; }
    }
}
