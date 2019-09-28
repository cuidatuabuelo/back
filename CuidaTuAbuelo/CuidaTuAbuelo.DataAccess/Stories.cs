using System;
using System.Collections.Generic;
using System.Text;

namespace CuidaTuAbuelo.DataAccess
{
    public class Stories : Base
    {
        public int storyId { get; set; }
        public int userId { get; set; }
        public string comments { get; set; }
        public int score { get; set; }
    }
}
