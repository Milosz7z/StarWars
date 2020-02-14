using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain.Repositories
{
    public interface IStarWarsCharacterRepository
    {
        void Create(StarWarsCharacterEntity starWarsCharacterEntity);
        StarWarsCharacterEntity Get(string name);
        IEnumerable<StarWarsCharacterEntity> GetAll();
        void Update(StarWarsCharacterEntity starWarsCharacterEntity, string name);
        void Delete(string name);
    }
}
