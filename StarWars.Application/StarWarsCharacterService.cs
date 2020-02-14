using StarWars.Contracts;
using StarWars.Domain.Repositories;
using StarWars.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWars.Domain;

namespace StarWars.Application
{
    public class StarWarsCharacterService
    {
        private readonly CharacterParser _characterParser;
        private readonly IStarWarsCharacterRepository _starWarsCharacterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StarWarsCharacterService(CharacterParser characterParser, IStarWarsCharacterRepository starWarsCharacterRepository, IUnitOfWork unitOfWork)
        {
            _characterParser = characterParser;
            _starWarsCharacterRepository = starWarsCharacterRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<StarWarsCharacterDto> GetAllCharacters()
        {
            var characterEntities = _starWarsCharacterRepository.GetAll();
            return characterEntities.Select(x => _characterParser.CharacterEntityToDto(x));
        }

        public StarWarsCharacterDto GetCharacter(string name)
        {
            var characterEntity = _starWarsCharacterRepository.Get(name);
            return _characterParser.CharacterEntityToDto(characterEntity);
        }

        public void CreateCharacter(StarWarsCharacterDto characterDto)
        {
            var characterEntity = new StarWarsCharacterEntity();

            _starWarsCharacterRepository.Create(characterEntity.Create(characterDto.Name, characterDto.Episodes, characterDto.Friends, characterDto.Planet));
            _unitOfWork.Commit();
        }

        public void UpdateCharacter(string name, StarWarsCharacterDto characterDto)
        {
            var characterEntity = _characterParser.CharacterDtoToEntity(characterDto);
            _starWarsCharacterRepository.Update(characterEntity, name);
            _unitOfWork.Commit();
        }

        public void DeleteCharacter(string name)
        {
            _starWarsCharacterRepository.Delete(name);
            _unitOfWork.Commit();
        }
    }
}
