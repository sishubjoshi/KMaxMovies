using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.KMaxMovies.Services.Models
{
	public class Show
	{
        public string ShowId { get; set; }
        [Required]
        [StringLength(8)]
        public string ScreenId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string MovieId { get; set; }
        public bool IsFull { get; set; }
    }
}
