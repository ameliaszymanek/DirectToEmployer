using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DirectToEmployer.Models
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}