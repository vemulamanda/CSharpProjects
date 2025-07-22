using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAppAutomaticMigrationExample.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string Sname { get; set; }
        public int? Class {  get; set; }
    }
}