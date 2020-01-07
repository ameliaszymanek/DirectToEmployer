using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Suspense Date & Time")]
        public DateTime Suspense { get; set; }

        [DisplayName("Desired Skills")]
        public string DesiredSkills { get; set; }

        [DisplayName("Job Summary")]
        public string JobPostingSummary { get; set; }

        [DisplayName("Application Challenge")]
        public string ApplicationChallenge { get; set; }

        [ForeignKey ("Employer")]
        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}