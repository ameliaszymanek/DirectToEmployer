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

        // GET: Application/Details/5
        public ActionResult Details(int id)
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

        //public ActionResult NewSubmission(Guid? id, JobPosting jobPosting)
        //{
        //    //find logged in user
        //    var userId = User.Identity.GetUserId();
        //    Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
        //    //jobPosting??

        //    //create new application
        //    new Application { ApplicationId = Guid.NewGuid() };
        //    return View(new Application { ApplicationId = Guid.NewGuid(), JobPostingId = jobPosting.JobPostingId });
        //}

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
    }
}
