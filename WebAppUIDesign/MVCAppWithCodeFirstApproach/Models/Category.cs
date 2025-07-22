using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAppWithCodeFirstApproach.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [NotMapped] //use this "notmapped" to avoid creating this property in database.
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}