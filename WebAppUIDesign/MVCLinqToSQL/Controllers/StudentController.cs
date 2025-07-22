using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLinqToSQL.Models;

namespace MVCLinqToSQL.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL dal = new StudentDAL();
        public ViewResult DisplayStudents()
        {
            var Students = dal.GetStudents(true); 
            return View(Students);
        }

        public ViewResult DisplayStudent(int Sid)
        {
            var Student = dal.GetStudent(Sid, true);
            return View(Student);
        }

        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student Student, HttpPostedFileBase selectedFile)
        {
            if(selectedFile != null)
            {
                string folderpath = Server.MapPath("~/Uploads/");

                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }

                selectedFile.SaveAs(folderpath + selectedFile.FileName);
                Student.Photo = selectedFile.FileName;
            }
            Student.Status = true;

            dal.InsertStudent(Student);
            return RedirectToAction("DisplayStudents");
        }

        public ViewResult EditStudent(int Sid)
        {
            var student = dal.GetStudent(Sid, true);
            TempData["Photo"] = student.Photo;
            
            return View(student);
        }
        public RedirectToRouteResult UpdateStudent(Student Student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string folderpath = Server.MapPath("~/Uploads/");

                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                selectedFile.SaveAs(folderpath + selectedFile.FileName);
                Student.Photo = selectedFile.FileName;
            }
            else if (TempData["Photo"] != null)
            {
                Student.Photo = TempData["Photo"].ToString();
            }

            Student.Status = true;
            dal.UpdateStudent(Student);
            return RedirectToAction("DisplayStudents");
        }

        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            dal.DeleteStudent(Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}