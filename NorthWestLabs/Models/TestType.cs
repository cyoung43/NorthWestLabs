using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("TestTypes")]
    public class TestType
    {
        [Key]
        public int TestTypeID { get; set; }

        [DisplayName("Test Type Description")]
        public string TestTypeDesc { get; set; }

        [DisplayName("Test Procedure")]
        public string Procedure { get; set; }
    }
}