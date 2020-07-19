using Linkedin.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Experience")]

    public class Experience
    {
        public ExperienceType Type { get; set; }
        public Guid Id { get; set; }

    }
}
