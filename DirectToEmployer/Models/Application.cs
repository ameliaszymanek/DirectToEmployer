using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class Application
    {
        [Key]
        public Guid ApplicationId { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmailAddress { get; set; }
        public string ChallengeSolution { get; set; }
    }
}