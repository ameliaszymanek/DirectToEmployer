using DirectToEmployer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DirectToEmployer.Controllers
{
    public class JobseekerController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobseeker
        public ActionResult Index()
        {
            //string userId = User.Identity.GetUserId();
            //return View(db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId));
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult ApplicationHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewInterviews()
        {
            var userId = User.Identity.GetUserId();
            //first find jobseeker logged in
            Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
            //then find all itineraries that jobseeker has (jobseeker id)
            return View(db.Interviews.Where(i => i.JobseekerId == jobseeker.JobseekerId).ToList());
        }

        // GET: Jobseeker/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jobseeker/Create
        public ActionResult Create()
        {
            return View(new Jobseeker());
        }

        // POST: Jobseeker/Create
        [HttpPost]
        public ActionResult Create(Jobseeker Jobseeker)
        {
            Jobseeker.JobseekerId = Guid.NewGuid();
            Jobseeker.ApplicationId = User.Identity.GetUserId();
            db.Jobseekers.Add(Jobseeker);
            db.SaveChanges();
            return RedirectToAction("Index", "Jobseeker", new { id = Jobseeker.JobseekerId });
        }

        // GET: Jobseeker/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jobseeker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobseeker/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jobseeker/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
