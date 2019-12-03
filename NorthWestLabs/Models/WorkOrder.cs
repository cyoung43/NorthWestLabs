using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("WorkOrders")]
    public class WorkOrder
    {
        [Key]
        public int WrkOrdID { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool RushOrder { get; set; }
        public string comments { get; set; }
        public int ReceivedBy { get; set; }
        public int ClientID { get; set; }
    }
}