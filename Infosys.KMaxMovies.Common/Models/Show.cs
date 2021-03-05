using System;
using System.Collections.Generic;
using System.Text;

namespace Infosys.KMaxMovies.Common.Models
{
    public class Show
    {
        public string ShowID { get; set; }
        public string ScreenID { get; set; }
        public System.DateTime Date { get; set; }
        public string Time { get; set; }
        public string MovieID { get; set; }
        public bool IsFull { get; set; }
    }
}
