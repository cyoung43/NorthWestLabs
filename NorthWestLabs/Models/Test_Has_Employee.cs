﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Test_Has_Employee")]
    public class Test_Has_Employee
    {
        [Key]
        [Display(Name ="Test ID")]
        [Column(Order = 1)]
        public int TestID { get; set; }

        [Key]
        [Display(Name ="Employee ID")]
        [Column(Order = 2)]
        public int EmpID { get; set; }

        [Required]
        [Display(Name ="Test Duration")]
        public float TestDuration { get; set; }
    }
}