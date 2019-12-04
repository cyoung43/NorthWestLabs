using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [StringLength(30)]
        public string ClFName { get; set; }

        [Required]
        [Display(Name = "Client Last Name")]
        [StringLength(50)]
        public string ClLName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(60)]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(60)]
        public string ClAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(60)]
        public string ClAddress2 { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Client Email")]
        [StringLength(60)]
        public string ClEmail { get; set; }

        //What does the phone validation do? What should we do to the database to confirm this?
        [Required]
        [Phone]
        [Display(Name = "Client Phone Number")]
        [StringLength(15)]
        public string ClPhone { get; set; }

        [Display(Name = "Bank Account Number")]
        [StringLength(30)]
        public string BankAccouNum { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(60)]
        [PasswordPropertyText]
        public string Password { get; set; }

        //This field will have things such as active, unconfirmed, etc.
        [Required]
        [Display(Name ="Client Status")]
        [StringLength(10)]
        public string ClStatus { get; set; }

        
        [Display(Name = "Bank Name")]
        public int BankID { get; set; }

        
        [Display(Name = "Discount Name")]
        public int DisID { get; set; }
    }
}