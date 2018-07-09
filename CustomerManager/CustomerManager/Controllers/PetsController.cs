using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealDatabaseManager;
using CustomerManager.Models;

namespace CustomerManager.Controllers
{
    public class PetsController : Controller
    {
        public IActionResult Index()
        {
			var database = new RealDatabase("Server=.;Database=PetsDatabase;Trusted_Connection=true;");
			var pets = database.GetAllPets();
			var response = new ListPetsModel();
			response.Pets = pets
				.Select(p => new PetModel()
				{
					PetId = p.PetId,
					Name = p.Name,
					Age = p.Age,
					IsSpotted = p.IsSpotted,
					Color = p.Color
				})
				.ToArray();
			return View(response);
		}
    }
}