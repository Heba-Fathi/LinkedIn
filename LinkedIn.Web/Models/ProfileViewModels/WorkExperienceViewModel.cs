using Linkedin.Models.Entites;
using Linkedin.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models.ProfileViewModels
{
    public class WorkExperienceViewModel
    {
        public WorkExperienceViewModel()
        {
            IsPresent = false;
        }
       
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual SavedPlace Company { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        [Required]
        public int StartMonth { get; set; }
        [Required]
        public int StartYear { get; set; }
       // [Required]
        public int? EndMonth { get; set; }
        //[Required]
        public int? EndYear { get; set; }
        public bool IsPresent { get; set; }
    }
}