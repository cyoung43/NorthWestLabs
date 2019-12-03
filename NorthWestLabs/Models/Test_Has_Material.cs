using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("TestType_Has_Material")]
    public class Test_Has_Material
    {
        [Key]
        [Display(Name = "Test ID")]
        public int TestID { get; set; }

        [Key]
        [Display(Name ="Material ID")]
        public int MatID { get; set; }

        [Required]
        [Display(Name = "Unit Quantity")]
        public float UnitQty { get; set; }
    }
}