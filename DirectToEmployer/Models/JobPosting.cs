using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class JobPosting
    {
        [Key]
        public Guid JobPostingId { get; set; }
        public string JobTitle { get; set; }
        public DateTime Suspense { get; set; }
        public string DesiredSkills { get; set; }
        public string JobPostingSummary { get; set; }
        public string ApplicationChallenge { get; set; }

        [ForeignKey ("Employer")]
        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}