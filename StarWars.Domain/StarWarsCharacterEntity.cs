using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain
{
    public class StarWarsCharacterEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<EpisodeEntity> Episodes { get; private set; }
        public IEnumerable<FriendEntity> Friends { get; private set; }
        public string Planet { get; private set; }

        public StarWarsCharacterEntity()
        {

        }

        public StarWarsCharacterEntity(Guid id, string name, IEnumerable<EpisodeEntity> episodes, IEnumerable<FriendEntity> friends, string planet)
        {
            Id = id;
            Name = name;
            Episodes = episodes;
            Friends = friends;
            Planet = planet;
        }

        public StarWarsCharacterEntity Create(string name, IEnumerable<string> episodes,
            IEnumerable<string> friends, string planet)
        {
            List<EpisodeEntity> episodesCollection = new List<EpisodeEntity>();
            foreach (var dtoEpisode in episodes)
            {
                episodesCollection.Add(new EpisodeEntity(Guid.NewGuid(), dtoEpisode));
            }

            List<FriendEntity> friendsCollection = new List<FriendEntity>();
            foreach (var dtoFriend in friends)
            {
                friendsCollection.Add(new FriendEntity(Guid.NewGuid(), dtoFriend));
            }

            return new StarWarsCharacterEntity(Guid.NewGuid(), name, episodesCollection, friendsCollection, planet);
        }
    }
}
