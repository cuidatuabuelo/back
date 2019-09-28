using System;
using System.Collections.Generic;
using System.Text;

namespace CuidaTuAbuelo.DataAccess
{
    public class Transactions : Base
    {
        public int transactionId { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public int serviceId { get; set; }
        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }
        public double transactionValue { get; set; }
        public string notes { get; set; }
        public int transactionScore { get; set; }
        public int userScore { get; set; }
        public int nurseScore { get; set; }

    }
}
