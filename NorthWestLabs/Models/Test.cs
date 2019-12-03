using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Tests")]
    public class Test
    {
        [Key]
        [Display(Name ="Test ID")]
        public int TestID { get; set; }

        [Required]
        [Display(Name ="Test Name")]
        public string TestName { get; set; }

        //Look back through pricing stuff... I think I needed to do something else with it but I don't remember
        [Required]
        [Display(Name = "Base Price")]
        public float BasePrice { get; set; }
    }
}