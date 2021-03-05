using Infosys.KMaxMovies.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.KMaxMovies.Services.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ShowController : Controller
    {
        public AdminBL adminBL;

        public ShowController()
        {
            adminBL = new AdminBL();
        }

        [HttpGet]
        public JsonResult GetAllShows()
        {
            List<Common.Models.Show> shlist;
            try
            {
                shlist = adminBL.GetAllShows();
            }
            catch (Exception)
            {
                shlist = null;
            }
            return Json(shlist);
        }
    }
}
