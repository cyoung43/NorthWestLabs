using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        [Display(Name ="Bank ID")]
        public int BankID { get; set; }
        [Required]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Required]
        [Display(Name = "Bank Routing Number")]
        public string BankRoutingNum { get; set; }
    }
}