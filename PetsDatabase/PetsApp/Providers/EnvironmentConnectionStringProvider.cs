using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetsDatabase;

namespace PetsApp.Providers
{
	public class EnvironmentConnectionStringProvider : IConnectionStringProvider
	{
		public string GetConnectionString()
		{
			return Environment.GetEnvironmentVariable("PetConStr");
		}
	}
}
