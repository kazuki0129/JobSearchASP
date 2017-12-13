using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AspAssignmnet.Models
{
    public class CompanyMetadata
    {
        [StringLength(50)]
        [Display(Name="Company Name")]
        public string CompanyName;

        [Display(Name = "Company Adress")]
        public string CompanyAdress;

        [Display(Name = "Discription of Company")]
        public string CompanyDescription;
    }

    public class JobMetadata
    {
        [StringLength(50)]
        [Display(Name="Job Name")]
        public string JobName;

        [Display(Name = "Description of Job")]
        public string JobDescription;

        [Display(Name = "Location")]
        public string JobLocation;

        [Display(Name = "Position")]
        public string JobPosiotion;

        [Display(Name = "Published Date")]
        public Nullable<System.DateTime> JobPublishedDate;
    }
}