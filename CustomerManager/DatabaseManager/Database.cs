using System;
using System.Collections.Generic;

namespace DatabaseManager
{
    public class Database
    {
		public List<Customer> Customers { get; } = new List<Customer>()
		{
			new Customer() { FirstName = "Alice", LastName = "Smith" },
			new Customer() { FirstName = "Bob", LastName = "Smith" },
			new Customer() { FirstName = "Charlie", LastName = "Johnson" }
		};
    }
}
