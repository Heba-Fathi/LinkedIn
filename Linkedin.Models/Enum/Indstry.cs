using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Enum
{
    public enum Indstry
    {
        [Display(Name= "Computer SoftWare")]
        ComputerSoftWare,
        Chemicals,
        Banking,
        Design,
        [Display(Name = "E-buisness")]
        E_buisness,
        Entertainment


    }
}
