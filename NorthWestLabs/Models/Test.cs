using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Tests")]
    public class Test
    {
        [Key]
        [Display(Name ="Test ID")]
        public int TestID { get; set; }

        [Display(Name ="Test Result")]
        public bool TestResult { get; set; }

        [Required]
        [Display(Name ="Test Tube Number")]
        public int TestTubeNum { get; set; }

        [Required]
        [Display(Name = "Sequence Code")]
        public int SequenceCode { get; set; }

        [Required]
        [Display(Name ="Assay ID")]
        public int AssayID { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Results")]
        public HttpPostedFileBase File { get; set; }
    }
}