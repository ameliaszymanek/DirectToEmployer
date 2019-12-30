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

        //////// GET: Checklist/Create
        //////public ActionResult Create()
        //////{
        //////    return View();
        //////}

        //////// POST: Checklist/Create
        //////[HttpPost]
        //////public ActionResult Create(FormCollection collection)
        //////{
        //////    try
        //////    {
        //////        // TODO: Add insert logic here

        //////        return RedirectToAction("Index");
        //////    }
        //////    catch
        //////    {
        //////        return View();
        //////    }
        //////}

        // GET: Checklist/Edit/5
        public ActionResult Edit(Guid id)
        {
            var ChecklistToEdit = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            return View(ChecklistToEdit);
        }

        // POST: Checklist/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Checklist ChecklistToEdit)
        {
            ChecklistToEdit = db.Checklists.Where(c => c.ChecklistId == id).SingleOrDefault();
            if(ChecklistToEdit.CompanyResearch == true)
            {
                db.SaveChanges();
                return RedirectToAction("Details", "Interview");
            }

            ChecklistToEdit.CompanyResearch = false;
            db.SaveChanges();
            return RedirectToAction("Details", "Interview");
        }

        // GET: Checklist/CompanyResearchTips
        public ActionResult CompanyResearchTips()
        {
            return View("CompanyResearchTips");
        }

        // GET: Checklist/QuestionsToPrepareTips
        public ActionResult QuestionsToPrepareTips()
        {
            return View("QuestionsToPrepareTips");
        }

        //GET: Checklist/PracticeQuestionsTips
        public ActionResult PracticeQuestionsTips()
        {
            return View("PracticeQuestionsTips");
        }

        //GET: Checklist/ResponsesToPrepareTips
        public ActionResult ResponsesToPrepareTips()
        {
            return View("ResponsesToPrepareTips");
        }

        //GET: Checklist/PracticeResponsesTips
        public ActionResult PracticeResponsesTips()
        {
            return View("PracticeResponsesTips");
        }

        //GET: Checklist/Tips
        public ActionResult WhatToWearTips()
        {
            return View("WhatToWearTips");
        }

        //GET: Checklist/Tips
        public ActionResult PrepareOutfitTips()
        {
            return View("PrepareOutfitTips");
        }

        //GET: Checklist/Tips
        public ActionResult WhatToBringTips()
        {
            return View("WhatToBringTips");
        }

        //GET: Checklist/Tips
        public ActionResult PrepareInterviewEssentialsTips()
        {
            return View("PrepareInterviewEssentialsTips");
        }

        //GET: Checklist/Tips
        public ActionResult InterviewFollowUpTips()
        {
            return View("InterviewFollowUpTips");
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
