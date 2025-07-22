using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppToConnectWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}