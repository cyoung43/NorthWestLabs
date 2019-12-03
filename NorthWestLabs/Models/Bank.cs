using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string BankRoutingNum { get; set; }
    }
}