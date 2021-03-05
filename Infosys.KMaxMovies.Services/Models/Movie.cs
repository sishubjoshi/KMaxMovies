using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.KMaxMovies.Services.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public bool IsRunning { get; set; }
    }
}
