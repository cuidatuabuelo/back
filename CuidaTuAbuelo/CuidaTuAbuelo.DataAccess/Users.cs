using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CuidaTuAbuelo.DataAccess
{
    public class Users : Base
    {
        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string identification { get; set; }
        public string age { get; set; }
        public DateTime birthDate { get; set; }
        public string bloodType { get; set; }
        public string diseases { get; set; }
        public string disabilities { get; set; }
        public string profile { get; set; }
        public bool status { get; set; }
        public string imageUrl { get; set; }

    }
}
