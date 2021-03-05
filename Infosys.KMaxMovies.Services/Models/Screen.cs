using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.KMaxMovies.Services.Models
{
	public class Screen
	{
        public string ScreenId { get; set; }
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
        public string Multiplex { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }
}
