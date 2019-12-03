using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Display(Name ="Employee ID")]
        public int EmpID { get; set; }

        [Required]
        [Display(Name = "Employee First Name")]
        public string EmpFName { get; set; }

        [Required]
        [Display(Name = "Employee Last Name")]
        public string EmpLName { get; set; }

        [Required]
        [Display(Name = "Employee Wage")]
        public float EmpWage { get; set; }

        //Employee type
        [Required]
        [Display(Name="Employee Type")]
        public int EmpType { get; set; }
    }
}