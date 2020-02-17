using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWars.Application;
using StarWars.Contracts;
using StarWars.Domain;
using Xunit;

namespace StarWars.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("Luke", "Alderaan")]
        public void Parsing_character_entity_to_character_dto(string name, string planet)
        {
            // Arrange
            var episodes = new List<EpisodeEntity>();
            var friends = new List<FriendEntity>();
            episodes.Add(new EpisodeEntity(Guid.NewGuid(), "New Hope"));
            episodes.Add(new EpisodeEntity(Guid.NewGuid(), "Empire"));
            friends.Add(new FriendEntity(Guid.NewGuid(), "R2D2"));
            friends.Add(new FriendEntity(Guid.NewGuid(), "HanSolo"));
            var characterEntity = new StarWarsCharacterEntity(Guid.NewGuid(), name, episodes, friends, planet);
            CharacterParser parser = new CharacterParser();

            // Act 
            var characterDto = parser.CharacterEntityToDto(characterEntity);

            // Assert
            Assert.Equal(characterEntity.Id, characterDto.Id);
            Assert.Equal(characterEntity.Name, characterDto.Name);
            Assert.Equal(characterEntity.Planet, characterDto.Planet);
            Assert.Equal(characterEntity.Episodes.Select(x => x.EpisodeName), characterDto.Episodes);
            Assert.Equal(characterEntity.Friends.Select(x => x.FriendName), characterDto.Friends);
        }

        [Theory]
        [InlineData("Luke", "Alderaan")]
        public void Parsing_character_dto_to_character_entity(string name, string planet)
        {
            // Arrange
            var episodes = new List<string>() { "New Hope", "Empire", "Jedi" };
            var friends = new List<string>() { "Leia", "Han Solo", "Joda" };
            StarWarsCharacterDto characterDto = new StarWarsCharacterDto { Id = Guid.NewGuid(), Name = name, Planet = planet, Episodes = episodes, Friends = friends };
            CharacterParser parser = new CharacterParser();

            // Act 
            var characterEntity = parser.CharacterDtoToEntity(characterDto);

            // Assert
            Assert.Equal(characterDto.Id, characterEntity.Id);
            Assert.Equal(characterDto.Name, characterEntity.Name);
            Assert.Equal(characterDto.Planet, characterEntity.Planet);
            Assert.Equal(characterDto.Episodes, characterEntity.Episodes.Select(x => x.EpisodeName));
            Assert.Equal(characterDto.Friends, characterEntity.Friends.Select(x => x.FriendName));
        }
    }
}
