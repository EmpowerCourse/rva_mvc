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
    [Route("api/People")]
    public class CustomersController : Controller
    {
		[HttpGet]
		public string Get()
		{
			return "Get was called!";
		}

		[HttpPost]
		public void Post([FromBody]Customer customer)
		{

			// Normal


			// Everything here.


			var x = "";
		}
    }
}