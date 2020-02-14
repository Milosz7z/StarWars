using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application;
using StarWars.Contracts;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        private readonly StarWarsCharacterService _characterService;

        public StarWarsController(StarWarsCharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public IEnumerable<StarWarsCharacterDto> Get()
        {
            return _characterService.GetAllCharacters();
        }

        [HttpGet("{id}", Name = "Get")]
        public StarWarsCharacterDto Get(string name)
        {
            return _characterService.GetCharacter(name);
        }

        [HttpPost]
        public void Post([FromBody] StarWarsCharacterDto characterDto)
        {
            _characterService.CreateCharacter(characterDto);
        }

        [HttpPut("{id}")]
        public void Put(string name, [FromBody] StarWarsCharacterDto characterDto)
        {
            _characterService.UpdateCharacter(name, characterDto);
        }

        [HttpDelete("{id}")]
        public void Delete(string name)
        {
            _characterService.DeleteCharacter(name);
        }
    }
}
