using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAppOneToManyRelationExample.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string Ename { get; set; }
        public string Job {  get; set; }
        public double Salary { get; set; }
        public int Did { get; set; }
        
        [ForeignKey("Did")]
        public Department Departments { get; set; }
    }
}