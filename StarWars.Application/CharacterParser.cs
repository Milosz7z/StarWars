using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWars.Contracts;
using StarWars.Domain;

namespace StarWars.Application
{
    public class CharacterParser
    {
        public StarWarsCharacterDto CharacterEntityToDto(StarWarsCharacterEntity characterEntity)
        {
            if (characterEntity == null)
                return null;

            return new StarWarsCharacterDto { Id = characterEntity.Id, Name = characterEntity.Name, Friends = characterEntity.Friends?.Select(x => x.FriendName), Episodes = characterEntity.Episodes?.Select(x => x.EpisodeName), Planet = characterEntity.Planet };
        }

        public StarWarsCharacterEntity CharacterDtoToEntity(StarWarsCharacterDto characterDto)
        {
            if (characterDto == null)
                return null;

            List<EpisodeEntity> episodesCollection = new List<EpisodeEntity>();
            foreach (var dtoEpisode in characterDto.Episodes)
            {
                episodesCollection.Add(new EpisodeEntity(Guid.NewGuid(), dtoEpisode));
            }

            List<FriendEntity> friendsCollection = new List<FriendEntity>();
            foreach (var dtoFriend in characterDto.Friends)
            {
                friendsCollection.Add(new FriendEntity(Guid.NewGuid(), dtoFriend));
            }

            return new StarWarsCharacterEntity(characterDto.Id, characterDto.Name, episodesCollection, friendsCollection, characterDto.Planet);
        }
    }
}
