using System;
using System.Collections.Generic;

namespace PetsDatabase
{
	public interface IDatabase
	{
		void Create(Pet pet);
		Pet Read(int petId);
		IEnumerable<Pet> ReadAll();
		void Update(Pet pet);
		void Delete(int petId);
	}
}
