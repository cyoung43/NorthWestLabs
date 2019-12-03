using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Discounts")]
    public class Discount
    {
        [Key]
        [Display(Name ="Discount ID")]
        public int DisID { get; set; }

        [Required]
        [Display(Name = "Discount Amount")]
        public float DisAmt { get; set; }
    }
}