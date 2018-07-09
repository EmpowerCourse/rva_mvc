using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RealDatabaseManager
{
    public class RealDatabase
    {
		private readonly string connectionString;

		public RealDatabase(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public IEnumerable<PetDto> GetAllPets()
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = "SELECT * FROM Pet";
					using (var rdr = com.ExecuteReader())
					{
						while (rdr.Read())
						{
							var pet = new PetDto()
							{
								PetId = rdr.GetInt32(0),
								Name = rdr.GetString(1),
								Age = rdr.GetInt32(2),
								IsSpotted = rdr.GetBoolean(3),
								Color = rdr.GetString(4)
							};
							yield return pet;
						}
					}
				}
			}
		}
    }
}
