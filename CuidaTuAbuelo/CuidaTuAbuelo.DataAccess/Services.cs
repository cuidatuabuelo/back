using System;
using System.Collections.Generic;
using System.Text;

namespace CuidaTuAbuelo.DataAccess
{
    public class Services : Base
    {
        public int serviceId { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public bool status { get; set; }

    }
}
