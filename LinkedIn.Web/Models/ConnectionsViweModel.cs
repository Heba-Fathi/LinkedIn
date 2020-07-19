using Linkedin.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
    public class ConnectionsViweModel
    {
        public List<ApplicationUser> ConnnectionList { get; set; }
        public ApplicationUser User { get; set; }
    }
}