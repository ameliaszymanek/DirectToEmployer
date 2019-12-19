using System;
using System.Collections.Generic;
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
        public bool CompanyResearch { get; set; }
        public bool QuestionsToPrepare {get; set;}
        public bool PracticeQuestions {get; set;}
        public bool ResponsesToPrepare{get; set;}
        public bool PracticeResponses {get; set;}
        public bool WhatToWear {get; set;}
        public bool PrepareOutfit {get; set;}
        public bool WhatToBring {get; set;}
        public bool PrepareInterviewEssentials {get; set;}
        public bool InterviewFollowUp { get; set; }

        [ForeignKey("Interview")]
        public Guid InterviewId { get; set; }
        public Interview Interview { get; set; }
    }
}