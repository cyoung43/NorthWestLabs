using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Test_Has_Material")]
    public class Test_Has_Material
    {
        [Key]
        public int TestID { get; set; }
        [Key]
        public int MatID { get; set; }
        public float UnitQty { get; set; }
    }
}