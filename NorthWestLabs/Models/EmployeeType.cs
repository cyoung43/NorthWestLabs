using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("EmployeeTypes")]
    public class EmployeeType
    {
        [Key]
        [Display(Name = "Employee Type ID")]
        public int EmpType { get; set; }

        [Required]
        [Display(Name="Employee Type Description")]
        public string EmpTypeDesc { get; set; }
    }
}