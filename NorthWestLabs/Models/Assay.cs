using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Assays")]
    public class Assay
    {
        [Key]
        [Display(Name ="Assay ID")]
        public int AssayID { get; set; }

        [Required]
        [Display(Name ="Assay Name")]
        public string AssayName { get; set; }

        [Required]
        [Display(Name ="Base Price")]
        public float BasePrice { get; set; }

        [Required]
        [Display(Name ="Assay Procedure")]
        public string AssayProcedure { get; set; }

        [Required]
        [Display(Name ="Days Estimate")]
        public float DaysEstimate { get; set; }
    }
}