using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        public int MatID { get; set; }
        public string MatName { get; set; }
        public string MatUnitMeas { get; set; }
        public float MatCostPerUnit { get; set; }
    }
}