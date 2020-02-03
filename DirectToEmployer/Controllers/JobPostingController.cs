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

        public ActionResult PublicJobPosting (Guid? id)
        {
            JobPosting jobposting = db.JobPostings.Where(j => j.JobPostingId == id).FirstOrDefault();
            return View(jobposting);
        }

        //get all open job postings
        public ActionResult OpenJobPostings()
        {
            DateTime currentDay = DateTime.Now;
            List<JobPosting> openJobPostings = db.JobPostings.ToList();
            List<JobPosting> descendingOrder = openJobPostings.Where(i => i.Suspense > currentDay).OrderByDescending(i => i.Suspense).ToList();
            List<JobPosting> ascendingOrder = new List<JobPosting>();
            for (int i = descendingOrder.Count - 1; i >= 0; i--)
            {
                //add current i to list
                ascendingOrder.Add(descendingOrder[i]);
            }

            return View(ascendingOrder);
            //return View(db.JobPostings.ToList());
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
            return RedirectToAction("JobPostings", "Employer");
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
        public ActionResult Delete()
        {
            return View();
        }

        // POST: JobPosting/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
                JobPosting jobPosting = db.JobPostings.Find(id);
                db.JobPostings.Remove(jobPosting);
                db.SaveChanges();
                return RedirectToAction("JobPostings", "Employer");
        }
    }
}
