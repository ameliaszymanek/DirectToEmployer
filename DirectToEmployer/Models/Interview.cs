using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Company Address")]
        public string CompanyAddress { get; set; }

        [DisplayName("Date & Time")]
        public DateTime DateAndTimeOfInterview { get; set; }

        [DisplayName("Distance")]
        public string DistanceToInterview { get; set; }

        [DisplayName("Duration")]
        public string DurationToInterview { get; set; }

        [ForeignKey("Jobseeker")]
        public Guid JobseekerId { get; set; }
        public Jobseeker Jobseeker { get; set; }
    }
}