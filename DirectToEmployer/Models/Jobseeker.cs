using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class Jobseeker
    {
        [Key]
        public Guid JobseekerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }

        [DisplayName("Industry")]
        public string Industry { get; set; }

        [DisplayName("Your Top Three Skills")]
        public string TopThreeSkills { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}