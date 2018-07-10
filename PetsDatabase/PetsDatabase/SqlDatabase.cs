using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetsDatabase
{
	public class SqlDatabase : IDatabase
	{
		private readonly string connectionString;

		public SqlDatabase(IConnectionStringProvider provider)
		{
			connectionString = provider.GetConnectionString();
		}

		public void Create(Pet pet)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = "INSERT INTO Pet ([Name], Age, IsSpotted, Color) VALUES (@Name, @Age, @IsSpotted, @Color)";
					com.Parameters.AddWithValue("@Name", pet.Name);
					com.Parameters.AddWithValue("@Age", pet.Age);
					com.Parameters.AddWithValue("@IsSpotted", pet.IsSpotted);
					com.Parameters.AddWithValue("@Color", pet.Color);
					com.ExecuteNonQuery();
				}
			}
		}

		public void Delete(int petId)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = "DELETE Pet WHERE PetId = @PetId";
					com.Parameters.AddWithValue("@PetId", petId);
					com.ExecuteNonQuery();
				}
			}
		}

		public Pet Read(int petId)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = @"
						SELECT *
						FROM Pet
						WHERE PetId = @PetId
						";
					com.Parameters.AddWithValue("@PetId", petId);
					using (var rdr = com.ExecuteReader())
					{
						rdr.Read();
						var pet = new Pet();
						pet.PetId = rdr.GetInt32(0);
						pet.Name = rdr.GetString(1);
						pet.Age = rdr.GetInt32(2);
						pet.IsSpotted = rdr.GetBoolean(3);
						pet.Color = rdr.GetString(4);
						return pet;
					}
				}
			}
		}

		public IEnumerable<Pet> ReadAll()
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = @"
						SELECT *
						FROM Pet
						";
					using (var rdr = com.ExecuteReader())
					{
						while (rdr.Read())
						{
							var pet = new Pet();
							pet.PetId = rdr.GetInt32(0);
							pet.Name = rdr.GetString(1);
							pet.Age = rdr.GetInt32(2);
							pet.IsSpotted = rdr.GetBoolean(3);
							pet.Color = rdr.GetString(4);
							yield return pet;
						}
					}
				}
			}
		}

		public void Update(Pet pet)
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand())
				{
					com.Connection = con;
					com.CommandText = @"
						UPDATE Pet SET
							[Name] = @Name,
							Age = @Age,
							IsSpotted = @IsSpotted,
							Color = @Color
						WHERE PetId = @PetId
						";
					com.Parameters.AddWithValue("@Name", pet.Name);
					com.Parameters.AddWithValue("@Age", pet.Age);
					com.Parameters.AddWithValue("@IsSpotted", pet.IsSpotted);
					com.Parameters.AddWithValue("@Color", pet.Color);
					com.Parameters.AddWithValue("@PetId", pet.PetId);
					com.ExecuteNonQuery();
				}
			}
		}
	}
}
