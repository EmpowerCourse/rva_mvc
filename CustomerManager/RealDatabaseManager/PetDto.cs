using System;
using System.Collections.Generic;
using System.Text;

namespace RealDatabaseManager
{
    public class PetDto
    {
		public int PetId { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public bool IsSpotted { get; set; }
		public string Color { get; set; }
    }
}
