using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTO;

namespace WebApplication3.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
	[Route("api/Trucks")]
	public class AutomobilesController : Controller
    {
		[HttpGet]
		public string Get()
		{
			return "You have found automobiles!";
		}

		[HttpPost]
		public void Post([FromBody]Drink drink)
		{
			if (!drink.Validate()) throw new Exception();
			// Do stuff
		}
	}
}