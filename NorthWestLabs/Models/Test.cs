using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWestLabs.Models
{
    [Table("Tests")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        public string TestName { get; set; }
        public float BasePrice { get; set; }
    }
}