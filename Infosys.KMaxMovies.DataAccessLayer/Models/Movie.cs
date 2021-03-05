using System;
using System.Collections.Generic;

namespace Infosys.KMaxMovies.DataAccessLayer.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Show = new HashSet<Show>();
        }

        public string MovieId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public bool IsRunning { get; set; }

        public ICollection<Show> Show { get; set; }
    }
}
