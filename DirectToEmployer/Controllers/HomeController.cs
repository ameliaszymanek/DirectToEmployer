using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectToEmployer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Jobseeker"))
            {
                return RedirectToAction("Index", "Jobseeker");
            }
            if (User.IsInRole("Employer"))
            {
                return RedirectToAction("Index", "Employer");
            }
            return View();
        }

        public ActionResult About()
        {
            if (User.IsInRole("Jobseeker"))
            {
                return RedirectToAction("About", "Jobseeker");
            }
            if (User.IsInRole("Employer"))
            {
                return RedirectToAction("About", "Employer");
            }

            return View();
        }

        public ActionResult ApplicationHome()
        {
            if (User.IsInRole("Jobseeker"))
            {
                return RedirectToAction("ApplicationHome", "Jobseeker");
            }
            if (User.IsInRole("Employer"))
            {
                return RedirectToAction("ApplicationHome", "Employer");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}