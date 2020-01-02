using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class Checklist
    {
        [Key]
        public Guid ChecklistId { get; set; }

        [DisplayName("Company Research")]
        public bool CompanyResearch { get; set; }

        [DisplayName("Prepare Questions")]
        public bool QuestionsToPrepare {get; set;}

        [DisplayName("Practice Questions")]
        public bool PracticeQuestions {get; set;}

        [DisplayName("Prepare Responses")]
        public bool ResponsesToPrepare{get; set;}

        [DisplayName("Practice Responses")]
        public bool PracticeResponses {get; set;}

        [DisplayName("What To Wear")]
        public bool WhatToWear {get; set;}

        [DisplayName("Prepare Outfit")]
        public bool PrepareOutfit {get; set;}

        [DisplayName("What To Bring To Interview")]
        public bool WhatToBring {get; set;}

        [DisplayName("Prepare Interview Essentials")]
        public bool PrepareInterviewEssentials {get; set;}

        [DisplayName("Interview Follow-Up")]
        public bool InterviewFollowUp { get; set; }

        [ForeignKey("Interview")]
        public Guid InterviewId { get; set; }
        public Interview Interview { get; set; }
    }
}