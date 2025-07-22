using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppOneToManyAndManyToManyRelationExample.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}