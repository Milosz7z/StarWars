using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWars.Domain;
using StarWars.Domain.Repositories;

namespace StarWars.Persistence
{
    public class StarWarsCharacterRepository : IStarWarsCharacterRepository
    {
        private readonly StarWarsContext _context;

        public StarWarsCharacterRepository(StarWarsContext context)
        {
            _context = context;
        }

        public void Create(StarWarsCharacterEntity starWarsCharacterEntity)
        {
            _context.Add(starWarsCharacterEntity);
        }

        public void Delete(string name)
        {
            var entityToDelete = _context.StarWarsCharacters.SingleOrDefault(x => x.Name == name);
            if (entityToDelete != null) _context.StarWarsCharacters.Remove(entityToDelete);
        }

        public StarWarsCharacterEntity Get(string name)
        {
            return _context.StarWarsCharacters.SingleOrDefault(x => x.Name == name);
        }

        public IEnumerable<StarWarsCharacterEntity> GetAll()
        {
            return _context.StarWarsCharacters;
        }

        public void Update(StarWarsCharacterEntity starWarsCharacterEntity, string name)
        {
            _context.Update(starWarsCharacterEntity);
        }
    }
}
