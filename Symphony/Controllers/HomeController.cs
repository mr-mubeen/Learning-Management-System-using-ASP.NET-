using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Symphony.Controllers;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Symphony.Models;
using System.Data.Entity;

namespace Symphony.Controllers
{
    public class HomeController : Controller
    {
       
        Database1Entities6 db1 = new Database1Entities6();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult About()
        {
            return View();
        }





        public ActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(register R)

        {
            register reg = db1.registers.Where(model => model.username == R.username && model.password == R.password).FirstOrDefault();
            if (reg != null)
            {
                if (reg.role_id == 1)
                {
                    Session["username"] = reg.username;
                    TempData["msg"] = "<script>alert('Login Succesfull')</script>";
                    return RedirectToAction("Admin", "Home");
                }
              
                
            }
            else
            {
                ViewData["msg"] = "<script>alert('User Not Found')</script>";
            }
            return View();
        }





        [HttpGet]
        public ActionResult register()
        {

            return View();
        }


        [HttpPost]
        public ActionResult register(register r)
        {
            register reg = db1.registers.Where(x => x.username == r.username).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (reg == null)
                {
                    var data = db1.registers.Add(r);
                    int a = db1.SaveChanges();

                    if (a > 0)
                    {

                        TempData["msg"] = "<script>alert('Registeration successfull')</script>"; ;
                        return RedirectToAction("login", "Home");
                    }
                    else
                    {
                        ViewData["msg"] = "<script>alert('Registration Failed')</script>";

                    }
                }
                else
                {
                    ViewData["msg"] = "<script>alert('Username Exists')</script>";
                }
            }
            else
            {
                ViewData["msg"] = "<script>alert('Enter All Values')</script>";
            }
            
            return View();

        }


        public ActionResult courses()
        {
            return View();
        }



        //[HttpGet]
        //public ActionResult graphic()
        //{
        //    //List<video> videolist = new List<video>();

        //    //string maincon = ConfigurationManager.ConnectionStrings["db2"].ConnectionString;
        //    //SqlConnection sqlcon = new SqlConnection(maincon);
        //    //string querry = "select * from videos";
        //    //SqlCommand sqlcom = new SqlCommand(querry, sqlcon);
        //    //sqlcon.Open();
        //    //SqlDataReader sdr = sqlcom.ExecuteReader();
        //    //while (sdr.Read())
        //    //{
        //    //    video v = new video();
        //    //    v.v_name = sdr["v_name"].ToString();
        //    //    v.v_path = sdr["v_path"].ToString();
        //    //    videolist.Add(v);
        //    //}
        //    //return View(videolist);
        //}






        [HttpPost]
        public ActionResult graphic(HttpPostedFileBase videofile)
        {
            if (videofile != null)
            {
                string filename = Path.GetFileName(videofile.FileName);
                if (videofile.ContentLength < 104857600)
                {
                    videofile.SaveAs(Server.MapPath("/Videos/" + filename));
                    string maincon = ConfigurationManager.ConnectionStrings["db2"].ConnectionString;
                    SqlConnection sqlcon = new SqlConnection(maincon);
                    string querry = "insert into videos values (@v_name,@v_path)";
                    SqlCommand sqlcom = new SqlCommand(querry, sqlcon);
                    sqlcon.Open();
                    sqlcom.Parameters.AddWithValue("@v_name", filename);
                    sqlcom.Parameters.AddWithValue("@v_path", "/Videos/" + filename);
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                    ViewData["message"] = "succesfully";

                }
            }

            return RedirectToAction("graphic", "home");
        }





        public ActionResult Instructor()
        {
            return View();
        }


        public ActionResult Instructor_profile()
        {

            return View();
        }












       



        //[HttpGet]
        //public ActionResult course_exam_create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult course_exam_create(course_exam ce)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        db1.course_exam.Add(ce);
        //        db1.SaveChanges();
        //        TempData["msg"] = "<script>alert('Data is Inserted')</script>";
        //        return RedirectToAction("course_exam", "Home");

        //    }
        //    else
        //    {
        //        ViewData["message"] = "<script>alert('Data is not Modified')</script>";
        //    }


        //    return View();


        //}


        //[HttpGet]
        //public ActionResult course_exam_edit(int id)
        //{
        //    var data = db1.course_exam.Where(model => model.c_exam_id == id).FirstOrDefault();
        //    return View(data);
        //}

        //[HttpPost]
        //public ActionResult course_exam_edit(course_exam ce)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        db1.Entry(ce).State = EntityState.Modified;
        //        int a = db1.SaveChanges();

        //        if (a > 0)
        //        {
        //            ViewData["message"] = "<script>alert('Data is Modified')</script>";

        //        }
        //        else
        //        {
        //            ViewData["message"] = "<script>alert('Data is not Modified')</script>";
        //        }
        //    }
        //    return RedirectToAction("course_exam", "Home");
        //}



        //public ActionResult course_exam_delete(int id)
        //{
        //    var data = db1.course_exam.Where(model => model.c_exam_id == id).FirstOrDefault();


        //    if (data != null)
        //    {
        //        db1.Entry(data).State = EntityState.Deleted;
        //        int a = db1.SaveChanges();

        //        if (a > 0)
        //        {
        //            TempData["DeleteMessage"] = "<script>alert('Data is Deleted')</script>";
        //        }
        //        else
        //        {
        //            TempData["DeleteMessage"] = "<script>alert('Data is not Deleted')</script>";
        //        }
        //    }

        //    return RedirectToAction("course_exam", "Home");
        //}


        //public ActionResult course_exam()
        //{
        //    var data = db1.course_exam.ToList();
        //    return View(data);
        //}


        //[HttpGet]
        //public ActionResult course()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult course(cours c)
        //{
        //    db1.courses1.Add(c);
        //    db1.SaveChanges();
        //    return View();
        //}













        // ------------ Student Ifo


       

        public ActionResult course_view()
        {
            // view courses 

            var data = db1.courses.ToList();

            return View(data);

        }


        public ActionResult admin_course_view()
        {
            var data = db1.courses.ToList();
            return View(data);

        }



        public ActionResult admin_course_delete(int id)
        {
            var data = db1.courses.Where(model => model.c_id == id).FirstOrDefault();


            if (data != null)
            {
                db1.Entry(data).State = EntityState.Deleted;
                int a = db1.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "<script>alert('Data is Deleted')</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Data is not Deleted')</script>";
                }
            }

            return RedirectToAction("admin_course_view", "Home");
        }

        [HttpGet]
        public ActionResult admin_add_course()
        {

            return View();

        }

        [HttpPost]
        public ActionResult admin_add_course(cours c)
        {

            cours cc = db1.courses.Where(model => model.c_name == c.c_name).FirstOrDefault();
            
            string file_name = Path.GetFileNameWithoutExtension(c.imagefile.FileName);
            string extension = Path.GetExtension(c.imagefile.FileName);
            file_name = file_name + DateTime.Now.ToString("yymmssfff") + extension;
            c.c_image = "~/Image/" + file_name;
            file_name = Path.Combine(Server.MapPath("~/Image/"), file_name);
            c.imagefile.SaveAs(file_name);
            using (db1)
            {
                if (cc == null)
            {
                    db1.courses.Add(c);

                    db1.SaveChanges();
                    TempData["msg"] = "<script>alert('Course Added Successfully')</script>";
                    
                    return RedirectToAction("admin_course_view", "Home");
                }
                else
                {
                    ViewData["msg"] = "<script>alert('Course Already Exists , Add Failed')</script>";
                }

               
            }


            ModelState.Clear();
            return View();

            

        }





        public ActionResult contact()
        {
            // user contact view
            var data = db1.locations.ToList();

            return View(data);

        }


        public ActionResult contact_admin_view()
        {

            var data = db1.locations.ToList();

            return View(data);

        }


        [HttpGet]
        public ActionResult contact_admin_create()
        {

            
            return View();

        }

        [HttpPost]
        public ActionResult contact_admin_create(location l)
        {
            string file_name = Path.GetFileNameWithoutExtension(l.imagefile.FileName);
            string extension = Path.GetExtension(l.imagefile.FileName);
            file_name = file_name + DateTime.Now.ToString("yymmssfff") + extension;
            l.image = "~/Image/" + file_name;
            file_name = Path.Combine(Server.MapPath("~/Image/"), file_name);
            l.imagefile.SaveAs(file_name);
            using (db1)
            {
                location l1 = db1.locations.Where(x => x.Address == l.Address).FirstOrDefault();

                if (l1 == null)
                {
                    db1.locations.Add(l);

                    db1.SaveChanges();
                    TempData["msg"] = "<script>alert('Data Inserted')</script>";
                    return RedirectToAction("contact_admin_view", "Home");
                }
                else
                {
                    ViewData["msg"] = "<script>alert('Location already exists')</script>";
                }
               
            }


            ModelState.Clear();
            return View();

            

        }





        


        public ActionResult contact_admin_delete(int id)
        {
            var data = db1.locations.Where(model => model.l_id == id).FirstOrDefault();


            if (data != null)
            {
                db1.Entry(data).State = EntityState.Deleted;
                int a = db1.SaveChanges();

                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is Deleted')</script>";
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is not Deleted')</script>";
                }
            }

            return RedirectToAction("contact_admin_view", "Home");
        }



        public ActionResult faq_view()
        {
            var data = db1.faqs.ToList();
            return View(data);

        }


        public ActionResult admin_faq_view()
        {
            var data = db1.faqs.ToList();
            return View(data);

        }


        [HttpGet]
        public ActionResult admin_faq_create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult admin_faq_create(faq fq)
        {
            db1.faqs.Add(fq);
            int a = db1.SaveChanges();
            if (a > 0)
            {
                ViewData["msg"] = "<script>alert('Data is Inserted')</script>";
                return RedirectToAction("admin_faq_view", "Home");
            }
            else
            {
                ViewData["msg"] = "<script>alert('Data is not Inserted')</script>";
            }
            return View();

        }


        [HttpGet]
        public ActionResult admin_faq_edit(int id)
        {
            var data = db1.faqs.Where(model => model.f_id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult admin_faq_edit(faq fq)
        {
            if (ModelState.IsValid == true)
            {
                db1.Entry(fq).State = EntityState.Modified;
                int a = db1.SaveChanges();

                if (a > 0)
                {
                    ViewData["message"] = "<script>alert('Data is Modified')</script>";
                }
                else
                {
                    ViewData["message"] = "<script>alert('Data is not Modified')</script>";
                }
            }
            return RedirectToAction("admin_faq_view", "Home");
        }


        public ActionResult admin_faq_delete(int id)
        {
            var data = db1.faqs.Where(model => model.f_id == id).FirstOrDefault();


            if (data != null)
            {
                db1.Entry(data).State = EntityState.Deleted;
                int a = db1.SaveChanges();

                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is Deleted')</script>";
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is not Deleted')</script>";
                }
            }

            return RedirectToAction("admin_faq_view", "Home");
        }



        public ActionResult lectures_view()
        {
            
                var data = db1.videos.ToList();
                return View(data);
   
        }

        public ActionResult lectures1()
        {

            var data = db1.videos.ToList();
            return View(data);

        }
        public ActionResult lectures2()
        {

            var data = db1.videos.ToList();
            return View(data);

        }
        public ActionResult lectures3()
        {

            var data = db1.videos.ToList();
            return View(data);

        }
        public ActionResult lectures4()
        {

            var data = db1.videos.ToList();
            return View(data);

        }
        public ActionResult lectures5()
        {

            var data = db1.videos.ToList();
            return View(data);

        }
        public ActionResult lectures6()
        {

            var data = db1.videos.ToList();
            return View(data);

        }



        public ActionResult admin_lectures_view()
        {

            var data = db1.videos.ToList();

            return View(data);


        }


        [HttpGet]
        public ActionResult admin_lectures_create()
        {

            ViewBag.c_id = new SelectList(db1.courses, "c_id", "c_name");
            return View();

        }

        [HttpPost]
        public ActionResult admin_lectures_create(video v)
        {
            string file_name = Path.GetFileNameWithoutExtension(v.videofile.FileName);
            string extension = Path.GetExtension(v.videofile.FileName);
            file_name = file_name + DateTime.Now.ToString("yymmssfff") + extension;
            v.video_path = "~/Videos/" + file_name;
            file_name = Path.Combine(Server.MapPath("~/Videos/"), file_name);
            v.videofile.SaveAs(file_name);
            using (db1)
            {


                db1.videos.Add(v);

                int a = db1.SaveChanges();
                if (a > 0)
                {
                    TempData["msg"] = "<script>alert('Lecture is inserted')</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Insert Failed')</script>";
                }
            }


            ModelState.Clear();
            ViewBag.c_id = new SelectList(db1.courses, "c_id", "c_name", v.c_id);

            return RedirectToAction("admin_lectures_view", "Home");

        }


        public ActionResult admin_lectures_delete(int id)
        {
            var data = db1.videos.Where(model => model.v_id == id).FirstOrDefault();


            if (data != null)
            {
                db1.Entry(data).State = EntityState.Deleted;
                int a = db1.SaveChanges();

                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is Deleted')</script>";
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is not Deleted')</script>";
                }
            }

            return RedirectToAction("admin_lectures_view", "Home");
        }


        public ActionResult results()
        {

            return View();

        }


        public ActionResult logout()
        {
            Session.Abandon();
            
            return RedirectToAction("Index" , "Home");

        }





        //public ActionResult Lectures(student s)
        //{
        //    student stu = db1.students.Where(model => model.c_id == s.c_id && model.roll_num == s.roll_num).FirstOrDefault();
        //    if (stu != null)
        //    {
        //        if (stu.c_id == 1)
        //        {

        //            return RedirectToAction("lectures_view", "Home");
        //        }
        //        else if (stu.c_id == 2)
        //        {

        //            return RedirectToAction("lectures_view", "Home");
        //        }
        //        else if (stu.c_id == 3)
        //        {

        //            return RedirectToAction("lectures_view", "Home");
        //        }
        //        else
        //        {
        //            ViewData["msg"] = " < script > alert('Course Id nOt found') </ script >";
        //        }


        //    }
        //    else
        //    {
        //        ViewData["msg"] = " < script > alert('Roll Number Or Course Id is not valid') </ script >";
        //    }
        //    return View();
        //}


        public ActionResult student_lecture_view(entance_exams e)
        {
            entance_exams ee = db1.entance_exams.Where(x => x.user_id == e.user_id && x.c_id == e.c_id).FirstOrDefault();
            if (ee != null)
            {
                if (e.c_id == 1)
                {
                    return RedirectToAction("lectures1", "Home");
                }
                else if (e.c_id == 2)
                {
                    return RedirectToAction("lectures2", "Home");
                }
                else if (e.c_id == 3)
                {
                    return RedirectToAction("lectures3", "Home");
                }
                else if (e.c_id == 4)
                {
                    return RedirectToAction("lectures4", "Home");
                }
                else if (e.c_id == 5)
                {
                    return RedirectToAction("lectures5", "Home");
                }
                else if (e.c_id == 6)
                {
                    return RedirectToAction("lectures6", "Home");
                }
                else
                {
                    ViewData["msg"] = "<script>alert('Course Not Found')</script>";
                }


            }
            else
            {
                ViewData["msg"] = "Data is not valid , Please Enter Valid Data";
            }
            return View();

        }



    }



}

    