using System;
using System.Linq;
using Xunit;
using PetsDatabase;

namespace PetsTests
{
    public class SqlDatabaseTests
    {
        [Fact]
        public void BigTest()
        {
			var db = new SqlDatabase(new HardCodedConnectionStringProvider());
			db.Create(new Pet() { Name = "Fido", Age = 2, IsSpotted = false, Color = "Brown and Red" });
			db.Create(new Pet() { Name = "Fluffy", Age = 13, IsSpotted = true, Color = "Gray" });
			var allPets = db.ReadAll().ToArray();
			Assert.Equal(2, allPets.Length);
			var fido = allPets[0];
			var fluffy = allPets[1];
			Assert.Equal("Fido", fido.Name);
			Assert.Equal(2, fido.Age);
			Assert.False(fido.IsSpotted);
			Assert.Equal("Brown and Red", fido.Color);
			Assert.Equal("Fluffy", fluffy.Name);
			Assert.Equal(13, fluffy.Age);
			Assert.True(fluffy.IsSpotted);
			Assert.Equal("Gray", fluffy.Color);
			var fluffyId = fluffy.PetId;
			var fluffyViaId = db.Read(fluffyId);
			Assert.Equal("Fluffy", fluffyViaId.Name);
			Assert.Equal(13, fluffyViaId.Age);
			Assert.True(fluffyViaId.IsSpotted);
			Assert.Equal("Gray", fluffyViaId.Color);
			Assert.Equal(fluffyId, fluffyViaId.PetId);
			fluffy.Age = 14;
			db.Update(fluffy);
			var fluffy14 = db.Read(fluffy.PetId);
			Assert.Equal(14, fluffy14.Age);
			db.Delete(fluffy.PetId);
			var onePet = db.ReadAll().Single();
			Assert.Equal(fido.PetId, onePet.PetId);
			db.Delete(fido.PetId);
			Assert.Empty(db.ReadAll());
		}
    }
}
