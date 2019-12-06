using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name = "First Name")]
        public string EmpFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string EmpLName { get; set; }

        [Required]
        [Display(Name = "Wage")]
        public double EmpWage { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(15)]
        [PasswordPropertyText]
        public string EmpPassword { get; set; }

        //Employee type
        [Required]
        [Display(Name="Type")]
        public int EmpType { get; set; }
    }
}