using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCAppWithDBFirstApproachUsingSP.Models;

namespace MVCAppWithDBFirstApproachUsingSP.Controllers
{
    public class StudentController : Controller
    {
        MVCDBEntities DC = new MVCDBEntities();
        public ViewResult DisplayStudents()
        {
            var students = DC.Student_Select(null, true);
            
            return View(students);
        }

        public ViewResult DisplayStudent(int Sid)
        {
            var student = DC.Student_Select(Sid, true).Single();
            return View(student);
        }

        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if(selectedFile != null)
            {
                string physicalPath = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }
                else
                {
                    selectedFile.SaveAs(physicalPath + selectedFile.FileName);
                    student.Photo = selectedFile.FileName;
                }
                
            }
            DC.Student_Insert(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }

        public ViewResult EditStudent(int Sid)
        {
            var student = DC.Student_Select(Sid, true).Single();
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        public RedirectToRouteResult UpdateStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string physicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }
                else
                {
                    selectedFile.SaveAs(physicalPath + selectedFile.FileName);
                    student.Photo = selectedFile.FileName;
                }
            }
            else if (TempData["Photo"] != null)
            {
                student.Photo = TempData["Photo"].ToString();   
            }
            DC.Student_Update(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }

        [HttpGet]
        public ViewResult DeleteStudent(int Sid)
        {
            var student = DC.Student_Select(Sid, true).Single();
            return View(student);
        }
        [HttpPost]
        public RedirectToRouteResult DeleteStudent(Student_Select_Result student)
        {
            DC.Student_Delete(student.Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}