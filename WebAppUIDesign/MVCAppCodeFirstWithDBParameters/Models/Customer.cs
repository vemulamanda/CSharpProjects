using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAppCodeFirstWithDBParameters.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Column(TypeName = "Money")]
        public decimal? Balance { get; set; }

        [Index] //setting index attribute for this column 
        [Required] //setting not null column for this column.
        [MaxLength(50)]
        [Column("Cname", TypeName = "Varchar")]
        public string CustomerName { get; set; }

        [StringLength(1000)]
        [Column(TypeName = "Varchar")]
        public string Address { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Custid { get; set; }

        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]  //setting the foriegn key (note: the foriegn key should be mentioned on the navigation property to make it a foriegn key)
        public Supplier Supplier { get; set; }
    }
}