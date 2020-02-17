using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain;
using StarWars.Persistence;
using Xunit;

namespace StarWars.Tests
{
    public class IntegrationTests
    {
        private readonly StarWarsContext _context;

        public IntegrationTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StarWarsContext>();
            optionsBuilder.UseInMemoryDatabase("InMemory");
            _context = new StarWarsContext(optionsBuilder.Options);
        }

        [Fact]
        public void DatabaseAndTableExist()
        {
            // Arrange 

            // Act 

            var characterEntity = _context.StarWarsCharacters.FirstOrDefault();

            // Assert 
        }

        [Fact]
        public void CanPersistEntity()
        {
            // Arrange 
            var episodes = new List<EpisodeEntity>();
            var friends = new List<FriendEntity>();
            episodes.Add(new EpisodeEntity(Guid.NewGuid(), "New Hope"));
            episodes.Add(new EpisodeEntity(Guid.NewGuid(), "Empire"));
            friends.Add(new FriendEntity(Guid.NewGuid(), "R2D2"));
            friends.Add(new FriendEntity(Guid.NewGuid(), "HanSolo"));
            var characterEntity = new StarWarsCharacterEntity(Guid.NewGuid(), "Luke", episodes, friends, "Alderaan");

            // Act 

            _context.StarWarsCharacters.Add(characterEntity);
            var result = _context.SaveChanges();

            // Assert 
            Assert.NotEqual(0, result);
        }
        [Fact]
        public void CanPersistAndReadEntity()
        {
            // Arrange 
            var episodes = new List<EpisodeEntity>();
            var friends = new List<FriendEntity>();
            episodes.Add(new EpisodeEntity(Guid.NewGuid(), "New Hope"));
            episodes.Add(new EpisodeEntity(Guid.NewGuid(), "Empire"));
            friends.Add(new FriendEntity(Guid.NewGuid(), "R2D2"));
            friends.Add(new FriendEntity(Guid.NewGuid(), "HanSolo"));
            var characterEntity = new StarWarsCharacterEntity(Guid.NewGuid(), "Luke", episodes, friends, "Alderaan");

            // Act 

            _context.StarWarsCharacters.Add(characterEntity);
            var result = _context.SaveChanges();

            var retrievedcharacter = _context.StarWarsCharacters.SingleOrDefault(x => x.Id == characterEntity.Id);

            // Assert 
            Assert.NotNull(retrievedcharacter);
            Assert.Equal(characterEntity.Id, retrievedcharacter.Id);
            Assert.Equal(characterEntity.Name, retrievedcharacter.Name);
            Assert.Equal(characterEntity.Planet, retrievedcharacter.Planet);
            Assert.Equal(characterEntity.Friends, retrievedcharacter.Friends);
            Assert.Equal(characterEntity.Episodes, retrievedcharacter.Episodes);
        }
    }
}
