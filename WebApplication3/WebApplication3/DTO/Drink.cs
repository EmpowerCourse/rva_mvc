using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.DTO
{
    public class Drink
    {
		public bool IsCarbonated { get; set; }
		public bool IsServedHot { get; set; }
		public string Name { get; set; }

		public bool Validate()
		{
			return Name != null;
		}
    }
}
