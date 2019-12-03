using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Compounds")]
    public class Compound
    {
        [Key]
        public string LTNumber { get; set; }
        public string CompName { get; set; }
        public int CompQty { get; set; }
        public float GivenWeight { get; set; }
        public float GivenMass { get; set; }
        public float ActualWeight { get; set; }
        public string SampleAppearance { get; set; }
        public float MTD { get; set; }
        public string Status { get; set; }
        public int WrkOrdID { get; set; }
    }
}