using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string ClFName { get; set; }
        public string ClLName { get; set; }
        public string ClAddress1 { get; set; }
        public string ClAddress2 { get; set; }
        public string ClEmail { get; set; }
        public string ClPhone { get; set; }
        public string BankAccouNum { get; set; }
        private string Password { get; set; }
        public int BankID { get; set; }
        public int DisID { get; set; }
    }
}