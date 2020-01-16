using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class Application
    {
        [Key]
        public Guid ApplicationId { get; set; }

        [DisplayName("Name")]
        public string ApplicantName { get; set; }

        [DisplayName("Email Address")]
        public string ApplicantEmailAddress { get; set; }

        [DisplayName("Application Challenge Solution")]
        public string ChallengeSolution { get; set; }

        [DisplayName("Portfolio Link")]
        public string ApplicantPortfolioLink { get; set; }

        [ForeignKey("JobPosting")]
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
    }
}