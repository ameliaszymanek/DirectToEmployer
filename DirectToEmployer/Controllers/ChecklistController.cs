using DirectToEmployer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectToEmployer.Controllers
{
    public class ChecklistController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        //////// GET: Checklist
        //////public ActionResult Index()
        //////{
        //////    return View();
        //////}

        // GET: Checklist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Checklist/Edit/5
        public ActionResult Edit(Guid id)
        {
            Checklist ChecklistToEdit = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(ChecklistToEdit);
        }

        // POST: Checklist/Edit/5
        [HttpPost]
        public ActionResult Edit(Checklist ChecklistToEdit)
        {
            //MVP but create a loop to go through all of the tasks to see if they're t/f save changes
            Checklist checklist = db.Checklists.Find(ChecklistToEdit.ChecklistId); 
            if (ChecklistToEdit.CompanyResearch == true)
            {
                checklist.CompanyResearch = true;
                db.SaveChanges();
            }

            if(ChecklistToEdit.QuestionsToPrepare == true)
            {
                checklist.QuestionsToPrepare = true;
                db.SaveChanges();
            }

            if(ChecklistToEdit.PracticeQuestions == true)
            {
                checklist.PracticeQuestions = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.ResponsesToPrepare == true)
            {
                checklist.ResponsesToPrepare = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.PracticeResponses == true)
            {
                checklist.PracticeResponses = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.WhatToWear == true)
            {
                checklist.WhatToWear = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.PrepareOutfit == true)
            {
                checklist.PrepareOutfit = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.WhatToBring == true)
            {
                checklist.WhatToBring = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.PrepareInterviewEssentials == true)
            {
                checklist.PrepareInterviewEssentials = true;
                db.SaveChanges();
            }

            if (ChecklistToEdit.InterviewFollowUp == true)
            {
                checklist.InterviewFollowUp = true;
                db.SaveChanges();
            }

            //ChecklistToEdit.QuestionsToPrepare = false;
            //ChecklistToEdit.PracticeQuestions = false;
            //ChecklistToEdit.ResponsesToPrepare = false;
            //ChecklistToEdit.PracticeResponses = false;
            //ChecklistToEdit.WhatToWear = false;
            //ChecklistToEdit.PrepareOutfit = false;
            //ChecklistToEdit.WhatToBring = false;
            //ChecklistToEdit.PrepareInterviewEssentials = false;
            //ChecklistToEdit.InterviewFollowUp = false;
            //db.SaveChanges();
            return RedirectToAction("ViewInterviews", "Jobseeker");
        }

        // GET: Checklist/CompanyResearchTips
        public ActionResult CompanyResearchTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        // GET: Checklist/QuestionsToPrepareTips
        public ActionResult QuestionsToPrepareTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/PracticeQuestionsTips
        public ActionResult PracticeQuestionsTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/ResponsesToPrepareTips
        public ActionResult ResponsesToPrepareTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/PracticeResponsesTips
        public ActionResult PracticeResponsesTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/Tips
        public ActionResult WhatToWearTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/Tips
        public ActionResult PrepareOutfitTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/Tips
        public ActionResult WhatToBringTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/Tips
        public ActionResult PrepareInterviewEssentialsTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }

        //GET: Checklist/Tips
        public ActionResult InterviewFollowUpTips(Guid id)
        {
            Checklist checklistTask = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(checklistTask);
        }


        // GET: Checklist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Checklist/Delete/5
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
