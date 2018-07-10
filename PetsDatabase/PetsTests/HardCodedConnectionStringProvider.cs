using System;
using PetsDatabase;

namespace PetsTests
{
	public class HardCodedConnectionStringProvider : IConnectionStringProvider
	{
		public string GetConnectionString()
		{
			return "Server=.;Database=PetsDatabase;Trusted_Connection=true;";
		}
	}
}
