using System;
using System.Collections.Generic;

namespace Infosys.KMaxMovies.DataAccessLayer.Models
{
    public partial class Screen
    {
        public Screen()
        {
            Show = new HashSet<Show>();
        }

        public string ScreenId { get; set; }
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
        public string Multiplex { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Show> Show { get; set; }
    }
}
