using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;
using MVCAppToConnectWebApi.Models;
using System.Threading.Tasks;
using System.IO;

namespace MVCAppToConnectWebApi.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        string serviceurl = ConfigurationManager.AppSettings.Get("WebApiUrl");
        public ViewResult DisplayStudents()
        {
            client.BaseAddress = new Uri(serviceurl + "Student");
            Task<HttpResponseMessage> getTask = client.GetAsync("Student");
            getTask.Wait();
            HttpResponseMessage response = getTask.Result;
            List<Student> students = response.Content.ReadAsAsync<List<Student>>().Result;
            return View(students);
        }
        public ViewResult DisplayStudent(int id)
        {
            client.BaseAddress = new Uri(serviceurl + "Student");
            Task<HttpResponseMessage> getTask = client.GetAsync("Student/" + id);
            getTask.Wait();
            HttpResponseMessage response = getTask.Result;
            Student student = response.Content.ReadAsAsync<Student>().Result;
            return View(student);
        }
        [HttpGet]
        public ViewResult AddStudent(Student student)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student, HttpPostedFileBase selectedfile)
        {
            if(selectedfile != null)
            {
                BinaryReader br = new BinaryReader(selectedfile.InputStream);
                student.Photo = br.ReadBytes(selectedfile.ContentLength);
            }
            client.BaseAddress = new Uri(serviceurl + "Student");
            Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Student", student);
            postTask.Wait();
            HttpResponseMessage response = postTask.Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayStudents");
            }
           else
            {
                return View("AddStudent");
            }
        }
        public ViewResult EditStudent(int id)
        {
            client.BaseAddress = new Uri(serviceurl);
            Task<HttpResponseMessage> getTask = client.GetAsync("Student/" + id);
            getTask.Wait();
            HttpResponseMessage response = getTask.Result;
            Student student = response.Content.ReadAsAsync<Student>().Result;
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        public ActionResult UpdateStudent(Student student, HttpPostedFileBase selectedfile)
        {
            if (selectedfile != null)
            {
                BinaryReader br = new BinaryReader(selectedfile.InputStream);
                student.Photo = br.ReadBytes(selectedfile.ContentLength);
            }
            else if (TempData["Photo"] != null)
            {
                student.Photo = (byte[])TempData["Photo"];
            }
            
            client.BaseAddress = new Uri(serviceurl);
            Task<HttpResponseMessage> putTask = client.PutAsJsonAsync("Student", student);
            putTask.Wait();
            HttpResponseMessage response = putTask.Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayStudents");
            }
            else
            {
                return View("EditStudent", student);
            }
        }
        public RedirectToRouteResult DeleteStudent(int id)
        {
            client.BaseAddress = new Uri(serviceurl);
            Task<HttpResponseMessage> deleteTask = client.DeleteAsync("Student/" + id);
            deleteTask.Wait();
            HttpResponseMessage response = deleteTask.Result;
            
            return RedirectToAction("DisplayStudents");
        }
    }
}