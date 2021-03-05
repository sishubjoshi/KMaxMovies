using System;
using System.Collections.Generic;

namespace Infosys.KMaxMovies.DataAccessLayer.Models
{
    public partial class Show
    {
        public string ShowId { get; set; }
        public string ScreenId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MovieId { get; set; }
        public bool IsFull { get; set; }

        public Movie Movie { get; set; }
        public Screen Screen { get; set; }
    }
}
