using System;

namespace PetsDatabase
{
    public interface IConnectionStringProvider
    {
		string GetConnectionString();
    }
}
