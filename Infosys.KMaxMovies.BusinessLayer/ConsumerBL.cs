using Infosys.KMaxMovies.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infosys.KMaxMovies.BusinessLayer
{
    public class ConsumerBL
    {
        ConsumerRepository repository;

        public ConsumerBL()
        {
            repository = new ConsumerRepository();
        }

        public bool AddScreen(Common.Models.Screen screenCommon)
        {
            bool status;
            try
            {
                status = repository.AddScreen(screenCommon);
            }
            catch (Exception ex)
            {

                status = false;
            }
            return status;
        }

        public List<Common.Models.Screen> GetAllScreens()
        {
            List<Common.Models.Screen> listCommonMovies = null;
            try
            {
                listCommonMovies = repository.GetAllScreens();

            }
            catch (Exception ex)
            {
                listCommonMovies = null;
            }
            return listCommonMovies;
        }

        public bool UpdateScreen(Common.Models.Screen screenCommon)
        {
            bool status;
            try
            {
                status = repository.UpdateScreen(screenCommon);
            }
            catch (Exception ex)
            {

                status = false;
            }
            return status;
        }

        public bool DeleteScreen(string showID)
        {
            bool status;
            try
            {
                status = repository.DeleteScreen(showID);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        
    }
}
