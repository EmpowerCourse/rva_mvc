using System;

namespace PetsDatabase
{
    public class Pet
    {
		public int PetId { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public bool IsSpotted { get; set; }
		public string Color { get; set; }
    }
}
