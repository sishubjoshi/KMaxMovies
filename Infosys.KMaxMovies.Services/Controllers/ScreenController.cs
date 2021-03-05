using Infosys.KMaxMovies.BusinessLayer;
using Infosys.KMaxMovies.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infosys.KMaxMovies.Services.Controllers
{
	[ApiController]
	[Route("api/[Controller]/[action]")]
	public class ScreenController : Controller
	{
		public ConsumerBL consumer;

		public ScreenController()
		{
			consumer = new ConsumerBL();
		}

		public JsonResult GetAllScreens()
		{
			List<Common.Models.Screen> screenList;
			List<Screen> newscreenList = new List<Screen>();

			try
			{
				screenList = consumer.GetAllScreens();
				if(screenList != null)
				{
					foreach(var screen in screenList)
					{
						newscreenList.Add(new Screen() { 
							Capacity = screen.Capacity,
							City = screen.City,
							IsActive = screen.isActive,
							Multiplex = screen.Multiplex,
							ScreenId = screen.ScreenID,
							ScreenNumber = screen.ScreenNumber
						});
					}
				}
			}
			catch (Exception)
			{
				screenList = null;
				newscreenList = null;
				throw;
			}
			return Json(newscreenList);
		}
	}
}
