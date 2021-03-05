using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Infosys.KMaxMovies.DataAccessLayer;
using Infosys.KMaxMovies.Common;
using Infosys.KMaxMovies.BusinessLayer;
using Infosys.KMaxMovies.Services.Models;

namespace Infosys.KMaxMovies.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        public AdminBL adminBL;

        public AdminController()
        {
            adminBL = new AdminBL();
        }
        public JsonResult GetMovies()
        {
            List<Common.Models.Movie> mvlist;
            try
            {
                mvlist = adminBL.GetAllMovies();
            }
            catch (Exception)
            {
                mvlist = null;
                throw;
            }
            return Json(mvlist);
        }

       public JsonResult GetMoviesByLanguage(string language)
        {
            List<Common.Models.Movie> gmbl;
            try
            {
                gmbl = adminBL.GetAllMoviesByLanguage(language);
            }
            catch (Exception)
            {
                gmbl = null;
                throw;
            }
            return Json(gmbl);
        }

        public JsonResult GetAllMovies()
        {
            List<Common.Models.Movie> movieList;
            List<Movie> newList = new List<Movie>();
            try
            {
                movieList = adminBL.GetAllMovies();
                foreach(var movie in movieList)
                {
                    newList.Add(new Movie(){
                        Language = movie.Language,
                        Name = movie.Name,
                        Genre = movie.Genre,
                        IsRunning = movie.IsRunning
                    });
                }
            }
            catch (Exception)
            {
                movieList = null;
                newList = null;
            }
            return Json(newList);
        }

        [HttpPost]
        public JsonResult AddShow(Show show)
		{
            int status = -99;
			try
			{
                if(ModelState.IsValid)
				{
                    Common.Models.Show newShow = new Common.Models.Show();
                    newShow.Date = show.Date;
                    newShow.IsFull = show.IsFull;
                    newShow.MovieID = show.MovieId;
                    newShow.ScreenID = show.ScreenId;
                    newShow.ShowID = show.ShowId;
                    newShow.Time = show.Time;
                    status = adminBL.AddShow(newShow);
                }
                else
				{
                    status = -98;
				}
           
			}
			catch (Exception)
			{
                status = -99;
				throw;
			}
            return Json(status);
		}
    }
}
