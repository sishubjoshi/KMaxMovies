using Infosys.KMaxMovies.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infosys.KMaxMovies.DataAccessLayer
{
    public class ConsumerRepository:KMaxMoviesRepository
    {
        public ConsumerRepository():base()
        {

        }
        public ConsumerRepository(KMaxMoviesDBContext _context):base(_context)
        {

        }

        #region DAL - CREATE
        public bool AddScreen(Common.Models.Screen newScreen)
        {
            bool status = false;
            try
            {
                Screen screenObj = new Screen();
                var numberOfScreens = Context.Screen.Count();
                screenObj.ScreenId = newScreen.City.Substring(0, 3) + newScreen.Multiplex.Substring(0, 3) + (numberOfScreens + 1).ToString();
                screenObj.ScreenNumber = newScreen.ScreenNumber;
                screenObj.Capacity = newScreen.Capacity;
                screenObj.Multiplex = newScreen.Multiplex;
                screenObj.City = newScreen.City;
                screenObj.IsActive = newScreen.isActive;
                Context.Screen.Add(screenObj);
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

        #region DAL - READ
        public List<Common.Models.Screen> GetAllScreens()
        {
            List<Screen> lstScreens = null;
            List<Common.Models.Screen> listCommonScreens = new List<Common.Models.Screen>();
            try
            {
                lstScreens = (from s in Context.Screen select s).ToList<Screen>();
                if (lstScreens.Any())
                {
                    foreach (Screen scr in lstScreens)
                    {
                        listCommonScreens.Add(new Common.Models.Screen()
                        {
                            ScreenID = scr.ScreenId,
                            ScreenNumber = scr.ScreenNumber,
                            Capacity = scr.Capacity,
                            City = scr.City,
                            Multiplex = scr.Multiplex,
                            isActive = scr.IsActive
                        });
                    }
                }
            }
            catch (Exception e)
            {
                listCommonScreens = null;
            }
            return listCommonScreens;
        }
        #endregion

        #region DAL - UPDATE
        public bool UpdateScreen(Common.Models.Screen newScreen)
        {
            bool status = false;
            try
            {
                Screen screenObj = Context.Screen.Find(newScreen.ScreenID);
                screenObj.ScreenNumber = newScreen.ScreenNumber;
                screenObj.Capacity = newScreen.Capacity;
                screenObj.Multiplex = newScreen.Multiplex;
                screenObj.City = newScreen.City;
                screenObj.IsActive = newScreen.isActive;
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

        #region DAL - DELETE
        public bool DeleteScreen(string screenID)
        {
            bool status = false;
            try
            {

                var screenObj = (from scr in Context.Screen
                                 where scr.ScreenId == screenID
                                 select scr).FirstOrDefault<Screen>();
                Context.Screen.Remove(screenObj);
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
    }
}
