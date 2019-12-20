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
    public class InterviewController : Controller
    {
        private ApplicationDbContext db;

        public InterviewController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Interview
        //public ActionResult Index()
        //{
        //    ////find user logged in
        //    //var userId = User.Identity.GetUserId();
        //    //Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
        //    ////send list of interviews to the view
        //    //var listOfInterviews = db.Interviews.Where(j => j.InterviewId == ).ToList();
        //    //return View();
        //    //might be able to do this within ViewInterviews View with foreach loop
        //}

        // GET: Interview/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Interview/Create
        public ActionResult Create(Guid? id)
        {
            var userId = User.Identity.GetUserId();
            Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(t => t.ApplicationId == userId);
            return View(new Interview { InterviewId = Guid.NewGuid(), JobseekerId = jobseeker.JobseekerId });

        }

        // POST: Interview/Create
        [HttpPost]
        public ActionResult Create(Interview interview)
        {
            //logged in user
            var userId = User.Identity.GetUserId();
            Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
            interview.JobseekerId = jobseeker.JobseekerId;
            interview.InterviewId = Guid.NewGuid();
            db.Interviews.Add(interview);
            db.SaveChanges();
            return View("Interview");
        }

        // GET: Interview/Edit/5
        public ActionResult Edit(Guid id)
        {
            //var EditingInterview = db.Interviews.FirstOrDefault(i => i.InterviewId == id);
            Interview EditingInt = db.Interviews.Find(id);
            //interview = db.Interviews.FirstOrDefault(i => i.InterviewId == id);
            return View("Edit", EditingInt);
        }

        // POST: Interview/Edit/5
        [HttpPost]
        public ActionResult Edit(Interview interview)
        {
            //gets detached from jobseeker when it hits here
            db.Entry(interview).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ViewInterviews", "Jobseeker");
        }

        // GET: Interview/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interview/Delete/5
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
