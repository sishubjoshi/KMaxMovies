using System;
using System.Collections.Generic;
using System.Text;

namespace Infosys.KMaxMovies.Common.Models
{
    public class Movie
    {
        public string MovieID { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public bool IsRunning { get; set; }
    }
}
