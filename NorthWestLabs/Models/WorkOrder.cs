using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("WorkOrders")]
    public class WorkOrder
    {
        [Key]
        [Display(Name = "Work Order ID")]
        public int WrkOrdID { get; set; }

        [Required]
        [Display(Name = "Date Received")]
        public DateTime ReceivedDate { get; set; }

        [Required]
        [Display(Name ="Date Due")]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name ="Rush Order")]
        public bool RushOrder { get; set; }

        //Don't think this should be required. I thought you put question marks for that?
        [Display(Name ="Comments")]
        public string comments { get; set; }

        [Required]
        [Display(Name ="Received By")]
        public int ReceivedBy { get; set; }

        [Required]
        [Display(Name ="Client ID")]
        public int ClientID { get; set; }
    }
}