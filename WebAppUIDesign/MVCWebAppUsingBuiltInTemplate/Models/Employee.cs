using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebAppUsingBuiltInTemplate.Models
{
	public class Employee
	{
        public int? id { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public double? salary { get; set; }
        public bool status { get; set; }
    }
}