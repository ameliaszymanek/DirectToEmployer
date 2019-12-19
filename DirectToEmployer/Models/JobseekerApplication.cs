using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class JobseekerApplication
    {
        [Key]
        public Guid JobseekerApplicationId { get; set; }

        [ForeignKey("Jobseeker")]
        public Guid JobseekerId { get; set; }
        public Jobseeker Jobseeker { get; set; }

        [ForeignKey("Application")]
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}