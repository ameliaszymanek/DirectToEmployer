using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DirectToEmployer.Models;
using System.Web.Mvc;

namespace DirectToEmployer.Controllers
{
    public class GmailController : Controller
    {
        // GET: Gmail
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Gmail gmail)
        {
            gmail.SendEmail();
            return View();
        }

    }
}