using DirectToEmployer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectToEmployer.Controllers
{
    public class ApplicationController : Controller
    {

        private ApplicationDbContext db;
        public ApplicationController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        //Jobseeker responds to a jobposting
        // GET: Application/ NewSubmission
        public ActionResult NewSubmission(Guid? id)
        {
            //find user logged in
            var userId = User.Identity.GetUserId();
            Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
            //find jobPosting that user clicked apply on
            JobPosting jobPostingRespondingTo = db.JobPostings.Where(i => i.JobPostingId == id).SingleOrDefault();
            new Application { ApplicationId = Guid.NewGuid() };
            return View(new Application { ApplicationId = Guid.NewGuid(), JobPostingId = jobPostingRespondingTo.JobPostingId });
        }

        // POST: Application/NewSubmission
        [HttpPost]
        public ActionResult NewSubmission(Application application, JobPosting jobPosting)
        {
            //find logged in user
            var userId = User.Identity.GetUserId();
            Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
            //link application to jobposting
            application.JobPostingId = jobPosting.JobPostingId;
            //new id for application
            application.ApplicationId = Guid.NewGuid();
            db.Applications.Add(application);
            //connnect to JobseekerApplication "junction" table
            JobseekerApplication jobseekerApplication = new JobseekerApplication();
            jobseekerApplication.JobseekerApplicationId = Guid.NewGuid();
            jobseekerApplication.JobseekerId = jobseeker.JobseekerId;
            jobseekerApplication.ApplicationId = application.ApplicationId;
            db.JobseekerApplications.Add(jobseekerApplication);
            db.SaveChanges();
            return View("ApplicationSubmitted");
        }

        //get confirmation page
        public ActionResult ApplicationSubmitted()
        {
            return View("ApplicationSubmitted");
        }

        //GET: Application/Submissions/5
        public ActionResult Submissions(Guid? id)
        {
            var userId = User.Identity.GetUserId();
            Employer employer = db.Employers.FirstOrDefault(e => e.ApplicationId == userId);
            //Guid coming in is jobposting id
            JobPosting jobposting = db.JobPostings.Where(j => j.JobPostingId == id && j.EmployerId == employer.EmployerId).FirstOrDefault();
            //find all applications linked to specific jobposting
            return View(db.Applications.Where(a => a.JobPostingId == jobposting.JobPostingId).ToList());
        }
    }
}
