using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("CompoundTypes")]
    public class CompoundType
    {
        [Key]
        public int LTNumber { get; set; }

        [Required]
        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }
    }
}