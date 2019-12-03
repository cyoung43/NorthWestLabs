using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Compound_Has_Test")]
    public class Compound_Has_Test
    {
        [Key]
        [Display(Name = "LT Number")]
        [StringLength(6, ErrorMessage = "LT Number Must be 6 characters long")]
        public string LTNumber { get; set; }

        [Required]
        [Display(Name = "Test ID")]
        public int TestID { get; set; }

        [Required]
        [Display(Name = "Sequence Code")]
        public int SequenceCode { get; set; }

        [Required]
        [Display(Name = "Test Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TestDate { get; set; }

        [Required]
        [Display(Name = "Test Result")]
        public bool TestResult { get; set; }

        [Required]
        [Display(Name = "Test Tube Number")]
        public int TestTubeNum { get; set; }
    }
}