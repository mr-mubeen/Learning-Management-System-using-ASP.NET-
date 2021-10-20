using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Symphony;

namespace Symphony.Controllers
{
    public class enrollsController : Controller
    {
        private Database1Entities6 db = new Database1Entities6();

        // GET: enrolls
        public ActionResult Index()
        {
            var enrolls = db.enrolls.Include(e => e.cours);
            return View(enrolls.ToList());
        }

        public ActionResult Index_view()
        {
            var data = db.entance_exams.ToList();
            return View(data);
        }

        // GET: enrolls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enroll enroll = db.enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        // GET: enrolls/Create
        public ActionResult Create()
        {
            ViewBag.c_id = new SelectList(db.courses, "c_id", "c_name");
            return View();
        }

        // POST: enrolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enroll_id,s_name,cell,c_id")] enroll enroll)
        {
            enroll e = db.enrolls.Where(x => x.cell == enroll.cell).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (e == null)
                {
                    db.enrolls.Add(enroll);
                    db.SaveChanges();
                    TempData["message"] = "<script>alert('Successfully Enrolled')</script>";
                    return RedirectToAction("Index" , "Home");
                }
                else
                {
                    ViewData["message"] = "Records already exists";
                }
               
            }

            ViewBag.c_id = new SelectList(db.courses, "c_id", "c_name", enroll.c_id);
            return View(enroll);
        }

        // GET: enrolls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enroll enroll = db.enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.c_id = new SelectList(db.courses, "c_id", "c_name", enroll.c_id);
            return View(enroll);
        }

        // POST: enrolls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enroll_id,s_name,cell,c_id")] enroll enroll)
        {
            enroll e = db.enrolls.Where(x => x.cell == enroll.cell).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (e == null)
                {
                    db.Entry(enroll).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["message"] = "Records already exists , please update different";
                }
                
            }
            ViewBag.c_id = new SelectList(db.courses, "c_id", "c_name", enroll.c_id);
            return View(enroll);
        }

        // GET: enrolls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enroll enroll = db.enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        // POST: enrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enroll enroll = db.enrolls.Find(id);
            db.enrolls.Remove(enroll);
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
