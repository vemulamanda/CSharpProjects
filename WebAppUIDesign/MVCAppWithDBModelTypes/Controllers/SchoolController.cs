using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithDBModelTablePerHierarchyTypeExample.Models;

namespace MVCAppWithDBModelTypes.Controllers
{
    public class SchoolController : Controller
    {

        SchoolDbNewContext dc = new SchoolDbNewContext();

        public ActionResult Index()
        {
            Student s1 = new Student
            {
                Id = 101,
                Name = "Sudheer",
                Phone = "123456",
                Address = "pune",
                Class = 10,
                Marks = 450.00f,
                Fees = 5000.00f
            };

            Student s2 = new Student
            {
                Id = 102,
                Name = "Eswar",
                Phone = "999456",
                Address = "Hyderabad",
                Class = 11,
                Marks = 500.00f,
                Fees = 10000.00f
            };

            Student s3 = new Student
            {
                Id = 103,
                Name = "Siri",
                Phone = "444456",
                Address = "Eluru",
                Class = 9,
                Marks = 100.00f,
                Fees = 4000.00f
            };


            Teacher t1 = new Teacher
            {
                Id = 1001,
                Name = "Suresh",
                Phone = "1234234",
                Address = "Gurgaon",
                Designation = "Lecturer",
                Salary = 19000.00,
                Subject = "Maths"
            };

            Teacher t2 = new Teacher
            {
                Id = 1002,
                Name = "Mahesh",
                Phone = "9994234",
                Address = "Delhi",
                Designation = "Lecturer",
                Salary = 26000.00,
                Subject = "Science"
            };

            Teacher t3 = new Teacher
            {
                Id = 1003,
                Name = "Nani",
                Phone = "0202893",
                Address = "Banglore",
                Designation = "Lecturer",
                Salary = 30000.00,
                Subject = "Social"
            };

            dc.People.Add(s1); dc.People.Add(s2); dc.People.Add(s3);
            dc.People.Add(t1); dc.People.Add(t2); dc.People.Add(t3);
            dc.SaveChanges();

            return View();
        }

        public ViewResult DisplayPeople()
        {
            var people = from p in dc.People select p;

            return View(people);
        }

        public ViewResult DisplayStudents()
        {
            var students = from p in dc.People.OfType<Student>() select p;
            return View(students);
        }

        public ViewResult DisplayTeachers()
        {
            var teachers = from p in dc.People.OfType<Teacher>() select p;
            return View(teachers);
        }
    }
}