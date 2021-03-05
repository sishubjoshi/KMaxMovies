 using Infosys.KMaxMovies.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Infosys.KMaxMovies.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Infosys.KMaxMovies.DataAccessLayer
{
    public class AdminRepository:KMaxMoviesRepository
    {
        public AdminRepository():base()
        {

        }
        public AdminRepository(KMaxMoviesDBContext _context):base(_context)
        {

        }

        # region DAL-CRUD operations

        #region DAL-CREATE methods
        public int AddShow(Common.Models.Show newShow)
        {
            System.Nullable<int> returnvalue = 0;
            try
            {
                var screenId = new SqlParameter("@ScreenID", newShow.ScreenID);
                var date = new SqlParameter("@Date", newShow.Date);
                var time = new SqlParameter("@Time", newShow.Time);
                var movieId = new SqlParameter("@MovieID", newShow.MovieID);
                returnvalue = Context.Database.ExecuteSqlCommand("usp_AddShow @ScreenID,@Date,@Time,@MovieID", 
                    parameters: new[] { screenId, date, time, movieId });                
            }
            catch (Exception ex)
            {
                returnvalue = -99;
            }
            //return 0;
            return Convert.ToInt32(returnvalue);
        }
        public bool AddMovie(Common.Models.Movie movie)
        {
            bool result = false;
            try
            {
                Movie newMovie = new Movie();
                newMovie.MovieId = movie.MovieID;
                newMovie.Name = movie.Name;
                newMovie.Language = movie.Language;
                newMovie.Genre = movie.Genre;
                newMovie.IsRunning = movie.IsRunning;
                Context.Movie.Add(newMovie);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        
        #endregion

        #region DAL-READ methods
        public List<Common.Models.Movie> GetAllMovies()
        {
            List<Movie> lstMovies = null;
            List<Common.Models.Movie> listCommonMovie = new List<Common.Models.Movie>();
            try
            {
                lstMovies = (from m in Context.Movie select m).ToList<Movie>();
                if (lstMovies.Any())
                {
                    foreach (Movie mov in lstMovies)
                    {
                        listCommonMovie.Add(new Common.Models.Movie()
                        { MovieID = mov.MovieId, Name = mov.Name, Language = mov.Language,
                            Genre = mov.Genre, IsRunning = mov.IsRunning });
                    }
                }
            }
            catch (Exception e)
            {
                listCommonMovie = null;
            }
            return listCommonMovie;
        }

        public List<Common.Models.Movie> GetAllMoviesByLanguage(string language)
        {
            List<Movie> lstMovies = null;
            List<Common.Models.Movie> listCommonMovie = new List<Common.Models.Movie>();
            try
            {
                lstMovies = (from m in Context.Movie where m.Language == language select m).ToList<Movie>();
                if (lstMovies.Any())
                {
                    foreach (Movie mov in lstMovies)
                    {
                        listCommonMovie.Add(new Common.Models.Movie()
                        { MovieID = mov.MovieId, Name = mov.Name, Language = mov.Language,
                            Genre = mov.Genre, IsRunning = mov.IsRunning });
                    }
                }
            }
            catch (Exception e)
            {
                listCommonMovie = null;
            }
            return listCommonMovie;
        }

       

        public List<Common.Models.Show> GetAllShows()
        {
            List<Common.Models.Show> lstShow = new List<Common.Models.Show>();
            try
            {
                var shows = (from c in Context.Show select c).ToList();
                foreach (var item in shows)
                {
                    Common.Models.Show show = new Common.Models.Show();
                    show.Date = item.Date;
                    show.IsFull = item.IsFull;
                    show.MovieID = item.MovieId;
                    show.ScreenID = item.ScreenId;
                    show.ShowID = item.ShowId;
                    show.Time = item.Time;
                    lstShow.Add(show);
                }
            }
            catch (Exception)
            {

                lstShow = null;
            }
            return lstShow;
        }
        #endregion

        #region DAL-UPDATE methods
        public bool UpdateShow(Common.Models.Show newShow)
        {
            bool status = false;
            try
            {
                Show showObj = Context.Show.Find(newShow.ShowID);
                showObj.ScreenId = newShow.ScreenID;
                showObj.Date = newShow.Date;
                showObj.Time = newShow.Time;
                showObj.MovieId = newShow.MovieID;
                Context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                status = false;
            }
            return status;
        }

        
        #endregion

        #region DAL-DELETE methods
        public bool DeleteShow(string showID)
        {
            bool status = false;
            try
            {

                var showObj = (from show in Context.Show
                               where show.ShowId == showID
                               select show).FirstOrDefault<Show>();
                Context.Show.Remove(showObj);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        
        #endregion

        #endregion
    }
}
