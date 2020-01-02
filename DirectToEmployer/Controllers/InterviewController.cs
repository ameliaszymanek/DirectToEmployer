using DirectToEmployer.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        // GET: Checklist/Details/5
        //have to put a hidden for on ViewInterviews so that the interviewId passes through
        public ActionResult InterviewChecklist(Guid? id)
        {
            Checklist checklist = db.Checklists.Where(c => c.InterviewId == id).FirstOrDefault();
            return View(checklist);
        }

        // GET: Interview/Create
        public ActionResult Create(Guid? id)
        {
            var userId = User.Identity.GetUserId();
            Jobseeker jobseeker = db.Jobseekers.FirstOrDefault(t => t.ApplicationId == userId);
            new Checklist { ChecklistId = Guid.NewGuid() };
            return View(new Interview { InterviewId = Guid.NewGuid(), JobseekerId = jobseeker.JobseekerId });

        }

        // POST: Interview/Create
        [HttpPost]
        public async Task<ActionResult> Create(Interview interview, Checklist checklist)
        {
            //logged in user
            var userId = User.Identity.GetUserId();
            Jobseeker thisJobseeker = db.Jobseekers.FirstOrDefault(j => j.ApplicationId == userId);
            interview.JobseekerId = thisJobseeker.JobseekerId;
            interview.InterviewId = Guid.NewGuid();
            await GetDistanceAndDuration(thisJobseeker, interview);
            db.Interviews.Add(interview);
            checklist.ChecklistId = Guid.NewGuid();
            checklist.InterviewId = interview.InterviewId;
            db.Checklists.Add(checklist);
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


        public async Task GetDistanceAndDuration(Jobseeker jobseeker, Interview interview)
        {
            string jobseekerAddress = jobseeker.HomeAddress;
            string interviewAddress = interview.CompanyAddress;
            var key = APIKey.GoogleDirectionsKey;
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={jobseekerAddress}&destination={interviewAddress}&key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                DirectionsJSON directionsJSON = JsonConvert.DeserializeObject<DirectionsJSON>(jsonresult);
                string duration = directionsJSON.routes[0].legs[0].duration.text;
                interview.DurationToInterview = duration;
                string distance = directionsJSON.routes[0].legs[0].distance.text;
                interview.DistanceToInterview = distance;
            }
        }

        // GET: Interview/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Interview/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Interview interview = db.Interviews.Find(id);
            db.Interviews.Remove(interview);
            db.SaveChanges();
            return RedirectToAction("ViewInterviews", "Jobseeker");
        }
    }
}
