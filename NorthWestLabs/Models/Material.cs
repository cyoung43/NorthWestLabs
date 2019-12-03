using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        [Display(Name ="Material ID")]
        public int MatID { get; set; }

        [Required]
        [Display(Name = "Material Name")]
        public string MatName { get; set; }

        [Required]
        [Display(Name ="Material Unit of Measure")]
        public string MatUnitMeas { get; set; }

        [Required]
        [Display(Name ="Material Cost Per Unit")]
        public float MatCostPerUnit { get; set; }
    }
}