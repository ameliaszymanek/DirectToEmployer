using DirectToEmployer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectToEmployer.Controllers
{
    public class JobPostingController : Controller
    {
        private ApplicationDbContext db;
        public JobPostingController()
        {
            db = new ApplicationDbContext();
        }

        // GET: JobPosting
        public ActionResult JobPosting(Guid? id)
        {
            JobPosting jobposting = db.JobPostings.Where(j => j.JobPostingId == id).FirstOrDefault();
            return View(jobposting);
        }


        // GET: JobPosting/Create
        public ActionResult Create(Guid? id)
        {
            var userId = User.Identity.GetUserId();
            Employer employer = db.Employers.FirstOrDefault(e => e.ApplicationId == userId);
            new JobPosting { JobPostingId = Guid.NewGuid() };
            return View(new JobPosting { JobPostingId = Guid.NewGuid(), EmployerId = employer.EmployerId });
        }

        // POST: JobPosting/Create
        [HttpPost]
        public ActionResult Create(JobPosting jobposting)
        {
            var userId = User.Identity.GetUserId();
            Employer employer = db.Employers.FirstOrDefault(e => e.ApplicationId == userId);
            jobposting.EmployerId = employer.EmployerId;
            jobposting.JobPostingId = Guid.NewGuid();
            db.JobPostings.Add(jobposting);
            db.SaveChanges();
            return View("JobPosting");
        }

        // GET: JobPosting/Edit/5
        public ActionResult Edit(Guid id)
        {
            JobPosting editingJobPosting = db.JobPostings.Find(id);
            return View("Edit", editingJobPosting);
        }

        // POST: JobPosting/Edit/5
        [HttpPost]
        public ActionResult Edit(JobPosting jobPosting)
        {
            db.Entry(jobPosting).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("JobPostings", "Employer");
        }

        // GET: JobPosting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobPosting/Delete/5
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
