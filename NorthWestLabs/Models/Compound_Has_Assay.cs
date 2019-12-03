using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Compound_Has_Assay")]
    public class Compound_Has_Assay
    {
        [Key]
        [Display(Name = "LT Number")]
        public int LTNumber { get; set; }

        [Required]
        [Display(Name = "Assay ID")]
        public int AssayID { get; set; }

        [Required]
        [Display(Name = "Assay Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AssayDate { get; set; }
    }
}