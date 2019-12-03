using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Compound_Has_Test")]
    public class Compound_Has_Test
    {
        [Key]
        public string LTNumber { get; set; }
        public int TestID { get; set; }
        public int SequenceCode { get; set; }
        public DateTime TestDate { get; set; }
        public bool TestResult { get; set; }
        public int TestTubeNum { get; set; }
    }
}