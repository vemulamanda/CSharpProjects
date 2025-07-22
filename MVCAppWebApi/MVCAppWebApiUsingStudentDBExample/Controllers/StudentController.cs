using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MVCAppWebApiUsingStudentDBExample.Models;

namespace MVCAppWebApiUsingStudentDBExample.Controllers
{
    public class StudentController : ApiController
    {
        MVCDBEntities dc = new MVCDBEntities();

        public List<Student> Get()
        {
            return dc.Students.Where(S =>S.Status == true).ToList();
        }
        public Student Get(int id)
        {
            return dc.Students.Find(id);
        }
        public HttpResponseMessage Post(Student student)
        {
            try
            {
                student.Status = true;
                dc.Students.Add(student);
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage Put(Student student)
        {
            try
            {
                Student obj = dc.Students.Find(student.Id);
                if(obj == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    obj.Name = student.Name;
                    obj.Photo = student.Photo;
                    obj.Status = true;
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
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Student obj = dc.Students.Find(id);
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
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
