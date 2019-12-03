using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Test_Has_Employee")]
    public class Test_Has_Employee
    {
        [Key]
        public int TestID { get; set; }
        [Key]
        public int EmpID { get; set; }
        public float TestDuration { get; set; }
    }
}