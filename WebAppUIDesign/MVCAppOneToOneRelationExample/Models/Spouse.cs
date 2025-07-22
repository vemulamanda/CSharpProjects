using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCAppOneToOneRelationExample.Models
{
    [Table("Spouse")]
    public class Spouse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, ForeignKey("Player")]
        public int PlayerId { get; set; }
        public string SpouseName { get; set; }
        public string SpouseProfession { get; set; }

        public Player Player { get; set; }
    }
}