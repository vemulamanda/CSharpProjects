using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class ParamsController : Controller
    {
        public string Index1(int id)            //If we use this method passing id value is compulsory.
        {
            return "The value of ID is: " + id;
        }
        public string Index2(int id = 0)        //If we use this method passing id value is optional, if no value is
                                                //passed 0 would be default value
        {
            return "The value of ID is: " + id;
        }
        public string Index3(int? id)           //If we use this method passing id value is optional, if no value is
                                                //passed "null" would be default value
        {
            return "The value of ID is: " + id;
        }
        public string Index4(string id)           //If we use this method passing id value is optional, if no value is
                                                //passed "null" would be default value, We are not using "?" here becoz strings are
                                                //by defaULT NULL
        {
            return "The value of ID is: " + id;
        }

        public string Index5(int? id, string name)           
        {
            return "The value of ID is: " + id + " and name is: " + name;            
        }
        public string Index6(int Pid, string Pname, int Price)
        {
            return $"ID is: {Pid}; Name is: {Pname}; Price is: {Price}";
        }
        public string Index7()
        {
            int Pid = int.Parse(Request.QueryString["Pid"]);
            string Pname = Request.QueryString["Pname"];
            double Price = double.Parse(Request.QueryString["Price"]);
            return $"ID is: {Pid}; Name is: {Pname}; Price is: {Price}";
        }

        //-----------------------------------------------------------------------------------------------
        public string Index8(string uname, string pwd)
        {
            if(uname == "Sudheer" &&  pwd == "Sudh@8143")
            {
                return "Login Successful..";
            }
            else
            {
                return "Please check username and password...";
            }
        }
        public string Index9()
        {
            string Uname = Request["uname"];
            string Pword = Request["pwd"];

            if (Uname == "Sudheer" && Pword == "Sudh@8143")
            {
                return "Login Successful..";
            }
            else
            {
                return "Please check username and password...";
            }
        }
        //-----------------------------------------------------------------------------------------------
        [ActionName("Index10")]
        public string Index10()
        {
            return "Hi Sudheer.";
        }
        [ActionName("Index11")]
        public string Index10(string name)
        {
            return $"Hi {name}.";
        }
        //-----------------------------------------------------------------------------------------------

        /*private string Display()
        {
            return "This is non action method and it wont respond to clients call.";
        }*/

        //OR
        
        [NonAction]
        public string Display()
        {
            return "If you want method to be public and want to not respond to clients call, write nonaction on top";
        }
    }
}