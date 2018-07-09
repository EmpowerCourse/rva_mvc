using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerManager.Models;
using DatabaseManager;

namespace CustomerManager.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
			var database = new Database();
			var customers = database.Customers;
			var response = new ListCustomersModel();
			response.Customers = customers
				.Select(c => new CustomerModel()
				{
					FirstName = c.FirstName,
					LastName = c.LastName
				})
				.ToArray();
            return View(response);
        }
    }
}