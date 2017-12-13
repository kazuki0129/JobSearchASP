using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AspAssignmnet.Models
{
    [MetadataType(typeof(CompanyMetadata))]
    public partial class Company
    {
    }

    [MetadataType(typeof(JobMetadata))]
    public partial class Job
    {
    }
}