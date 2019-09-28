using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CuidaTuAbuelo.DataAccess
{
    public class Products : Base
    {
        [Key]
        public int productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string provider { get; set; }
    }
}
