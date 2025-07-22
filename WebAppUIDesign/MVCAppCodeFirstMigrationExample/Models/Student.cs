using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAppCodeFirstMigrationExample.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Sname { get; set; }
        public int Class {  get; set; }

        [MaxLength(1)]
        [Column(TypeName = "Varchar")]
        public string Section { get; set; }
        public float? Fees { get; set; }
        public float? Marks { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}