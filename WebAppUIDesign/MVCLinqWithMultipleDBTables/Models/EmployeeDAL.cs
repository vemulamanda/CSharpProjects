using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.EnterpriseServices.CompensatingResourceManager;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLinqWithMultipleDBTables.Models
{
	public class EmployeeDAL
	{
		MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);

		public List<SelectListItem> GetDepartments()
		{
			List<SelectListItem> Depts = new List<SelectListItem>();

			foreach(var Dept in dc.Departments)
			{
				SelectListItem item = new SelectListItem
				{
					Text = Dept.Dname,
					Value = Dept.Did.ToString()
				};

				Depts.Add(item);
			}
			return Depts;
		}



		public EmpDept GetEmployee(int Eid)
		{
			var record = (from E in dc.Employees
						  join D in dc.Departments on E.Did equals D.Did
						  where E.Eid == Eid
						  select new
						  {
							  E.Eid,
							  E.Ename,
							  E.Job,
							  E.Salary,
							  D.Did,
							  D.Dname,
							  D.Location
						  }).Single();

			EmpDept Emp = new EmpDept
			{
				Eid = record.Eid,
				Ename = record.Ename,
				Job = record.Job,
				Salary = record.Salary,
				Did = record.Did,
				Dname = record.Dname,
				Location = record.Location
			};

			return Emp;
		}

		public List<EmpDept> GetEmployees()
		{
			var records = (from E in dc.Employees
						   join D in dc.Departments on E.Did equals D.Did
						   where E.Status == true
						   select new
						   {
							   E.Eid,
							   E.Ename,
							   E.Job,
							   E.Salary,
							   D.Did,
							   D.Dname,
							   D.Location
						   });

			List<EmpDept> Emps = new List<EmpDept>();
			foreach (var record in records)
			{
				EmpDept Emp = new EmpDept
				{
					Eid = record.Eid,
					Ename = record.Ename,
					Job = record.Job,
					Salary = record.Salary,
					Did = record.Did,
					Dname = record.Dname,
					Location = record.Location
				};

				Emps.Add(Emp);
			}
			return Emps;
		}

		public void Employee_Insert(EmpDept Emp)
		{
			try
			{
				Employee E = new Employee
				{
					Eid = Emp.Eid,
					Ename = Emp.Ename,
					Job = Emp.Job,
					Salary = Emp.Salary,
					Did = Emp.Did,
					Status = true
				};
				dc.Employees.InsertOnSubmit(E);
				dc.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Employee_Update(EmpDept newEmp)
		{
			try
			{
				Employee oldEmp = dc.Employees.Single(E => E.Eid == newEmp.Eid);

				oldEmp.Ename = newEmp.Ename;
				oldEmp.Job = newEmp.Job;
				oldEmp.Salary = newEmp.Salary;
				oldEmp.Did = newEmp.Did;

				dc.SubmitChanges();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void Employee_Delete(int Eid)
		{
			try
			{
				Employee oldEmp = dc.Employees.Single(E => E.Eid == Eid);
				oldEmp.Status = false;

				dc.SubmitChanges();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}