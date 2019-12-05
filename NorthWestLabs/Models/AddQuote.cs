using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    public class AddQuote
    {
        public int QCode { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Day Number")]
        public string DayNum { get; set; }

        [DisplayName("Total Price")]
        public int TotalPrice { get; set; }

        [DisplayName("Biochemical Pharmacology Test")]
        public bool BP { get; set; }

        [DisplayName("DiscoveryScreen Test")]
        public bool DS { get; set; }

        [DisplayName("ImmunoScreen Test")]
        public bool IS { get; set; }

        [DisplayName("ProfilingScreen Test")]
        public bool PF { get; set; }

        [DisplayName("PharmaScreen Test")]
        public bool PS { get; set; }

        [DisplayName("CustomScreen Test")]
        public bool CS { get; set; }

        [DisplayName("Custom Tests")]
        public string Custom { get; set; }

        [DisplayName("Comments/Instructions")]
        public string Comments { get; set; }
    }
}