using System;
using System.Collections.Generic;
using System.Text;

namespace Infosys.KMaxMovies.Common.Models
{
    public class Screen
    {
        public string ScreenID { get; set; }
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
        public string Multiplex { get; set; }
        public string City { get; set; }
        public bool isActive { get; set; }
    }
}
