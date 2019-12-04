using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWestLabs.Models
{
    [Authorize]
    [Table("WorkOrders")]
    public class WorkOrder
    {
        [Key]
        [Display(Name = "Work Order ID")]
        public int WrkOrdID { get; set; }

        [Required]
        [Display(Name = "Date Received")]
        [DataType("Date")]
        public DateTime ReceivedDate { get; set; }

        [Required]
        [Display(Name ="Date Due")]
        [DataType("Date")]
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

        [DisplayName("Work Order Report")]
        public string WOReport { get; set; }

        [Required]
        [Display(Name ="Client ID")]
        public int ClientID { get; set; }

        [DisplayName("Summary Status of Work Order")]
        public string SummaryStatus { get; set; }
    }
}