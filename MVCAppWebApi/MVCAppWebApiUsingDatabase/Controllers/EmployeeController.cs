using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Cors;
using MVCAppWebApiUsingDatabase.Models;

namespace MVCAppWebApiUsingDatabase.Controllers
{
    public class EmployeeController : ApiController
    {
        MVCDBEntities dc = new MVCDBEntities(); 

        public List<Employee> Get()
        {
            return dc.Employees.ToList();
        }
        public Employee Get(int Id)
        {
            return dc.Employees.Find(Id);
        }
        public HttpResponseMessage Post(Employee e)
        {
            try
            {
                e.Status = true;
                dc.Employees.Add(e);
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage Put(Employee e)
        {
            try
            {
                Employee obj = dc.Employees.Find(e.Eid);

                if(obj == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                obj.Ename = e.Ename;
                obj.Job = e.Job;
                obj.Salary = e.Salary;

                dc.Entry(obj).State = EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage delete(int Id)
        {
            try
            {
                Employee obj = dc.Employees.Find(Id);
                if(obj == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    obj.Status = false;
                    dc.Entry(obj).State = EntityState.Modified;
                    dc.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
