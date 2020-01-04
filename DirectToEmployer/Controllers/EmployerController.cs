﻿using DirectToEmployer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectToEmployer.Controllers
{
    public class EmployerController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employer
        public ActionResult Index()
        {
            //string userId = User.Identity.GetUserId();
            //return View(db.Employers.FirstOrDefault(j => j.ApplicationId == userId));
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        // GET: Employer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employer/Create
        public ActionResult Create()
        {
            Employer Employer = new Employer();
            return View(Employer);
        }

        //Company companies = db.Companies.ToList();
        //{
        //    Companies = companies
        //};

        // POST: Employer/Create
        [HttpPost]
        public ActionResult Create(Employer Employer)
        {
            Employer.EmployerId = Guid.NewGuid();
            Employer.ApplicationId = User.Identity.GetUserId();
            db.Employers.Add(Employer);
            db.SaveChanges();
            return RedirectToAction("Index", "Employer", new { id = Employer.EmployerId});
        }

        // GET: Employer/JobPostings
        [HttpGet]
        public ActionResult JobPostings()
        {
            var userId = User.Identity.GetUserId();
            Employer employer = db.Employers.FirstOrDefault(e => e.ApplicationId == userId);
            return View(db.JobPostings.Where(i => i.EmployerId == employer.EmployerId).ToList());
        }


        // GET: Employer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employer/Edit/5
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

        // GET: Employer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employer/Delete/5
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
