using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManager.Models
{
    public class PetModel
    {
		public int PetId { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public bool IsSpotted { get; set; }
		public string Color { get; set; }
	}
}
