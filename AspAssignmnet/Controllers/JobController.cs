using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspAssignmnet.Models;

namespace AspAssignmnet.Controllers
{
    public class JobController : Controller
    {
        private JobAssignmentMvcEntities db = new JobAssignmentMvcEntities();

        // GET: /Job/
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Company);
            return View(jobs.ToList());
        }

        public ActionResult ListJob(string searchByName, string searchByLocation)
        {
            var jobs = from jobname in db.Jobs
                       select jobname;

            if (!String.IsNullOrEmpty(searchByName))
            {
                jobs = jobs.Where(s => s.JobName.Contains(searchByName));
            }

            if (!String.IsNullOrEmpty(searchByLocation))
            {
                jobs = jobs.Where(s => s.JobLocation.Contains(searchByLocation));
            }
            

            return View(jobs);
        }

        [HttpPost]
        public string ListJob(FormCollection fc, string seachByName)
        {
            return "<h3> From [HttpPost] Index" + seachByName + "</h3>";
        }

        // GET: /Job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [Authorize]
        // GET: /Job/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            return View();
        }

        // POST: /Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="JobId,JobName,JobDescription,JobLocation,JobPosiotion,CompanyId,JobPublishedDate")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", job.CompanyId);
            return View(job);
        }

        // GET: /Job/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", job.CompanyId);
            return View(job);
        }

        // POST: /Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="JobId,JobName,JobDescription,JobLocation,JobPosiotion,CompanyId,JobPublishedDate")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", job.CompanyId);
            return View(job);
        }

        // GET: /Job/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
