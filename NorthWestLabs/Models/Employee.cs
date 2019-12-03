using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpFName { get; set; }
        public string EmpLName { get; set; }
        public float EmpWage { get; set; }
    }
}