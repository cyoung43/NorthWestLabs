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

        [DisplayName("Biochemical Pharmacology (BP)")]
        public bool BP { get; set; }

        [DisplayName("DiscoveryScreen (DS)")]
        public bool DS { get; set; }

        [DisplayName("ImmunoScreen (IS)")]
        public bool IS { get; set; }

        [DisplayName("ProfilingScreen (PF)")]
        public bool PF { get; set; }

        [DisplayName("PharmaScreen (PS)")]
        public bool PS { get; set; }

        [DisplayName("CustomScreen (CS)")]
        public bool CS { get; set; }

        [DisplayName("Custom Tests")]
        public string Custom { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }
    }
}