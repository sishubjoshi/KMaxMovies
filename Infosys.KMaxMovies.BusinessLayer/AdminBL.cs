using Infosys.KMaxMovies.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace Infosys.KMaxMovies.BusinessLayer
{
    public class AdminBL
    {
        AdminRepository repository;

        public AdminBL()
        {
            repository = new AdminRepository();
        }

        #region BusinessLayer-CRUD

        #region BusinessLayer-CREATE
        public int AddShow(Common.Models.Show showCommon)
        {
            int status;
            try
            {
                AdminRepository dalObj = new AdminRepository();
                status = dalObj.AddShow(showCommon);
            }
            catch (Exception )
            {

                status = -99;
            }
            return status;
        }

        
        public bool AddMovie(Common.Models.Movie movie)
        {
            bool result = false;
            try
            {
                AdminRepository adminRepository = new AdminRepository();
                result = adminRepository.AddMovie(movie);

            }
            catch (Exception )
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region BusinessLayer-READ
        

        #endregion


        #region BusinessLayer-UPDATE
        public bool UpdateShow(Common.Models.Show showCommon)
        {
            bool status;
            try
            {
                AdminRepository dalObj = new AdminRepository();
                status = dalObj.UpdateShow(showCommon);
            }
            catch (Exception )
            {

                status = false;
            }
            return status;
        }

        
        #endregion

        #region BusinessLayer-DELETE
        public bool DeleteShow(string showID)
        {
            bool status;
            try
            {
                AdminRepository dalObj = new AdminRepository();
                status = dalObj.DeleteShow(showID);
            }
            catch (Exception )
            {
                status = false;
            }
            return status;

        }

        #endregion
        #region BusinessLayer-READ
        public List<Common.Models.Movie> GetAllMovies()
        {
            List<Common.Models.Movie> listCommonMovies = null;
            try
            {
                AdminRepository dalObj = new AdminRepository();
                listCommonMovies = dalObj.GetAllMovies();

            }
            catch (Exception )
            {

                listCommonMovies = null;
            }
            return listCommonMovies;
        }

        public List<Common.Models.Show> GetAllShows()
        {
            List<Common.Models.Show> shows = new List<Common.Models.Show>();
            try
            {
                AdminRepository dalObj = new AdminRepository();
                shows = dalObj.GetAllShows();
            }
            catch (Exception)
            {

                shows = null;
            }
            return shows;
        }

        #endregion

        #region BusinessLayer-READ-Parameters
        public List<Common.Models.Movie> GetAllMoviesByLanguage(string language)
        {
            List<Common.Models.Movie> listCommonMovies = null;
            try
            {
                AdminRepository dalObj = new AdminRepository();
                listCommonMovies = dalObj.GetAllMoviesByLanguage(language);

            }
            catch (Exception )
            {

                listCommonMovies = null;
            }
            return listCommonMovies;
        }
        #endregion
        #endregion
    }
}
