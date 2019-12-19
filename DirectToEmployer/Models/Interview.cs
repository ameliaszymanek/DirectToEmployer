using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class Interview
    {
        [Key]
        public Guid InterviewId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTime DateAndTimeOfInterview { get; set; }
        public string DistanceToInterview { get; set; }
        public string DurationToInterview { get; set; }

        [ForeignKey("Jobseeker")]
        public Guid JobseekerId { get; set; }
        public Jobseeker Jobseeker { get; set; }
    }
}