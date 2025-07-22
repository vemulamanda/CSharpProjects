using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAppCodeFirstWithDBParameters.Models
{
    [Table("Supplier")] //Spec ifying the name for the table being created in the database 
    public class Supplier
    {
        [Key]   //setting this column as primary key column.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   //setting identity to off, so will not autogenerate values.
        public int Sid { get; set; }

        [MaxLength(100)] //setting maximum length as 100 for this column.
        [Column("Sname", TypeName = "Varchar")] //setting column name and data type  of column.
        public string SupplierName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}