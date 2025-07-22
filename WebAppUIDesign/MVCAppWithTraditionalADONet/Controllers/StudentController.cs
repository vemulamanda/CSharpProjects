using MVCAppWithTraditionalADONet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MVCAppWithTraditionalADONet.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL dal = new StudentDAL();
        public ActionResult DisplayStudents()
        {
            var Students = dal.Student_Select(null, true);
            return View(Students);
        }

        public ViewResult DisplayStudent(int Sid, bool Status)
        {
            var Student = dal.Student_Select(Sid, true)[0];
            return View(Student);
        }

        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }

        public RedirectToRouteResult AddStudent(Student student, HttpPostedFileBase selectedfile)
        {
            if(selectedfile != null)
            {
                string folderpath = Server.MapPath("~/Uploads/");

                if(!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }

                selectedfile.SaveAs(folderpath + selectedfile.FileName);
                student.Photo = selectedfile.FileName;
            }
            
            dal.Insert_Student(student);
            return RedirectToAction("DisplayStudents");
        }

        public ViewResult EditStudent(int Sid)
        {
            var student = dal.Student_Select(Sid, true)[0];
            TempData["Photo"] = student.Photo;
            return View(student);
        }

        public RedirectToRouteResult UpdateStudent(Student student, HttpPostedFileBase selectedfile)
        {
            if (selectedfile != null)
            {
                string folderpath = Server.MapPath("~/Uploads/");

                if(!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                selectedfile.SaveAs (folderpath + selectedfile.FileName);
                student.Photo = selectedfile.FileName;
            }
            else if (TempData["Photo"] != null)
            {
                student.Photo = TempData["Photo"].ToString();
            }

            dal.Update_Student(student);
            return RedirectToAction("DisplayStudents");
        }

        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            dal.Delete_Student(Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}