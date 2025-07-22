using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppOneToManyAndManyToManyRelationExample.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}