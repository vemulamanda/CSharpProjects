using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLinqWithMultipleDBTables.Models;

namespace MVCLinqWithMultipleDBTables.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL dal = new EmployeeDAL(); 
        public ViewResult DisplayEmployees()
        {
            var emps = dal.GetEmployees();

            return View(emps);
        }

        public ViewResult DisplayEmployee(int Eid)
        {
            var emp = dal.GetEmployee(Eid);

            return View(emp);
        }

        [HttpGet]
        public ViewResult AddEmployee()
        {
            EmpDept emp = new EmpDept();
            emp.Departments = dal.GetDepartments(); 
            return View(emp);
        }

        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept newemp)
        {
            EmpDept oldemp = new EmpDept
            {
                Eid = newemp.Eid,
                Ename = newemp.Ename,
                Job = newemp.Job,
                Salary = newemp.Salary,
                Did = newemp.Did,
            };

            dal.Employee_Insert(newemp);

            return RedirectToAction("DisplayEmployees");
        }

        public ViewResult EditEmployee(int Eid)
        {
            EmpDept emp = dal.GetEmployee(Eid);
            emp.Departments = dal.GetDepartments();
            return View(emp);
        }

        public RedirectToRouteResult UpdateEmployee(EmpDept emp)
        {
            dal.Employee_Update(emp);
            return RedirectToAction("DisplayEmployees");
        }

        public RedirectToRouteResult DeleteEmployee(int Eid)
        {
            dal.Employee_Delete(Eid);
            return RedirectToAction("DisplayEmployees");
        }
    }
}