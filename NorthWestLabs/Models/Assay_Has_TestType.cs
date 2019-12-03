using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Assay_Has_TestType")]
    public class Assay_Has_TestType
    {
        [Key]
        [Column(Order = 1)]
        public int AssayID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TestTypeID { get; set; }
    }
}