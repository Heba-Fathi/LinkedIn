using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Enum
{
    public enum EmploymentType
    {
        [Display(Name= "Full-Time")]
        Full_Time,
        [Display(Name = "Part-Time")]
        Part_Time,
        Freelance,
        Internship

    }
}
