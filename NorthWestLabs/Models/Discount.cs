using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Discounts")]
    public class Discount
    {
        [Key]
        public int DisID { get; set; }
        public float DisAmt { get; set; }
    }
}