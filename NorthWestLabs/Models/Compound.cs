using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Compounds")]
    public class Compound
    {

        [Key]
        [Display(Name = "LT Number")]
        public int LTNumber { get; set; }

        [Required]
        [Display(Name = "Compound Name")]
        public string CompName { get; set; }

        [Required]
        [Display(Name = "Compound Quantity")]
        public int CompQty { get; set; }

        [Required]
        [Display(Name = "Given Weight")]
        public float GivenWeight { get; set; }

        [Required]
        [Display(Name = "Given Mass")]
        public float GivenMass { get; set; }

        //This one is NOT required because it will only be entered if there is a difference
        [Display(Name = "Actual Weight")]
        public float ? ActualWeight { get; set; }

        //Still need to think about what this will hold. For now, I am thinking about holding things like "Great condition" "Good" "Fair" etc. Will talk to team members about this
        [Required]
        [Display(Name = "Sample Appearance")]
        public string SampleAppearance { get; set; }

        //Not required. ONly used for animal testing
        [Display(Name = "Maximum Tolerated Dose")]
        public float ? MTD { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Work Order ID")]
        public int WrkOrdID { get; set; }
    }
}