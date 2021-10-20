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
    public class entance_examsController : Controller
    {
        private Database1Entities6 db = new Database1Entities6();

        // GET: entance_exams
        public ActionResult Index()
        {
            var entance_exams = db.entance_exams.Include(e => e.enroll);
            return View(entance_exams.ToList());
        }


        public ActionResult Index_view(string search)
        {
          
            if (search == null)
            {
                var data = db.entance_exams.ToList();
                return View(data);
            }
            else
            {
                return View(db.entance_exams.Where(x => x.s_name == search).ToList());
            }
          
        }

        // GET: entance_exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entance_exams entance_exams = db.entance_exams.Find(id);
            if (entance_exams == null)
            {
                return HttpNotFound();
            }
            return View(entance_exams);
        }

        // GET: entance_exams/Create
        public ActionResult Create()
        {
            ViewBag.roll_num = new SelectList(db.enrolls, "enroll_id", "enroll_id");
            ViewBag.s_name = new SelectList(db.enrolls, "enroll_id", "s_name");
            ViewBag.c_id = new SelectList(db.courses, "c_id", "c_name");
            return View();
        }

        // POST: entance_exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roll_num,marks,c_id,fees,s_name,cell")] entance_exams entance_exams)
        {

            entance_exams ee = db.entance_exams.Where(x => x.roll_num == entance_exams.roll_num).FirstOrDefault();
           

            if (ModelState.IsValid)
            {
                if (ee == null)
                {
                    if (entance_exams.marks < 50)
                    {
                        ViewBag.msg = "Marks are less than 50 , Student is Failed , cannot enter data";
                    }
                    else if(entance_exams.marks > 100)
                    {
                        ViewBag.msg = "Marks should be less than or equal to 100 Student is Failed , cannot enter data";
                        
                    }
                    else
                    {
                        db.entance_exams.Add(entance_exams);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                          
                        
                        
                    
                }
                else
                {
                    ViewData["a"] = "Roll number already exists";
                }
                    
               
               
                
            }

            ViewBag.roll_num = new SelectList(db.enrolls, "enroll_id", "enroll_id", entance_exams.roll_num);
            ViewBag.s_name = new SelectList(db.enrolls, "enroll_id", "s_name", entance_exams.roll_num);
            ViewBag.c_id = new SelectList(db.courses, "c_id", "c_name", entance_exams.roll_num);
            return View(entance_exams);
        }

        // GET: entance_exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entance_exams entance_exams = db.entance_exams.Find(id);
            if (entance_exams == null)
            {
                return HttpNotFound();
            }
            ViewBag.roll_num = new SelectList(db.enrolls, "enroll_id", "s_name", entance_exams.roll_num);
            return View(entance_exams);
        }

        // POST: entance_exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roll_num,marks,c_id,fees,s_name,cell")] entance_exams entance_exams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entance_exams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roll_num = new SelectList(db.enrolls, "enroll_id", "s_name", entance_exams.roll_num);
            return View(entance_exams);
        }

        // GET: entance_exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entance_exams entance_exams = db.entance_exams.Find(id);
            if (entance_exams == null)
            {
                return HttpNotFound();
            }
            return View(entance_exams);
        }

        // POST: entance_exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entance_exams entance_exams = db.entance_exams.Find(id);
            db.entance_exams.Remove(entance_exams);
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
