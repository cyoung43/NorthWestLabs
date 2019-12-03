using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "Client First Name")]
        public string ClFName { get; set; }

        [Required]
        [Display(Name = "Client Last Name")]
        public string ClLName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string ClAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string ClAddress2 { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Client Email")]
        public string ClEmail { get; set; }

        //What does the phone validation do? What should we do to the database to confirm this?
        [Required]
        [Phone]
        [Display(Name = "Client Phone Number")]
        public string ClPhone { get; set; }

        [Display(Name = "Bank Account Number")]
        public string BankAccouNum { get; set; }

        [Required]
        [Display(Name = "Password")]
        private string Password { get; set; }

        //This field will have things such as active, unconfirmed, etc.
        [Required]
        [Display(Name ="Client Status")]
        public string ClStatus { get; set; }

        [Required]
        [Display(Name = "Bank ID")]
        public int BankID { get; set; }

        [Required]
        [Display(Name = "Discount ID")]
        public int DisID { get; set; }
    }
}