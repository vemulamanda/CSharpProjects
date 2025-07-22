using MVCAppWithDBFirstApproachNewExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVCAppWithDBFirstApproachNewExample.Controllers
{
    public class EmployeeController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        public ViewResult DisplayEmployees()
        {
            var emps = dc.Employees.Where(E => E.Status == true);

            //This below code will get 2 tables(employe, department in one single connection.)
            
            //dc.Configuration.LazyLoadingEnabled = false;
            //var emps = dc.Employees.Where(E => E.Status == true).Include(E => E.Department);

            return View(emps);
        }
        public ViewResult DisplayEmployee(int Eid)
        {          
            var emp = dc.Employees.Find(Eid);

            //This below code will get 2 tables(employee, department in one single connection.)

            //var emp = dc.Employees.Where(E => E.Eid == Eid).Include(E => E.Department).Single();

            return View(emp);
        }
        [HttpGet]
        public ViewResult AddEmployee()
        {
            ViewBag.Did = new SelectList(dc.Departments, "Did", "Dname");
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(Employee emp)
        {
            emp.Status = true;
            dc.Employees.Add(emp);
            dc.SaveChanges();

            return RedirectToAction("DisplayEmployees");
        }

        public ViewResult EditEmployee(int Eid)
        {
            var emp = dc.Employees.Find(Eid);
            ViewBag.Did = new SelectList(dc.Departments, "Did", "Dname", emp.Did);
            return View(emp);
        }

        public RedirectToRouteResult UpdateEmployee(Employee emp)
        {
            emp.Status = true;
            dc.Entry(emp).State = EntityState.Modified;
            dc.SaveChanges();

            return RedirectToAction("DisplayEmployees");
        }

        [HttpGet]
        public ViewResult DeleteEmployee(int Eid)
        {
            var emp = dc.Employees.Find(Eid);
            ViewBag.Did = new SelectList(dc.Departments, "Did", "Dname", emp.Did);
            return View(emp);
        }
        [HttpPost]
        public RedirectToRouteResult DeleteEmployee(Employee emp)
        {
            dc.Entry(emp).State= EntityState.Modified;
            //dc.Employees.Remove(emp);  To permanantly delete the record in database.
            dc.SaveChanges();

            return RedirectToAction("DisplayEmployees");
        }
    }
}