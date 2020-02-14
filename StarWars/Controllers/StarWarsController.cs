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
        public IEnumerable<StarWarsCharacterDto> Get([FromQuery] PaginationParameters paginationParameters)
        {
            return _characterService.GetAllCharacters(paginationParameters);
        }

        [HttpGet("{name}", Name = "Get")]
        public StarWarsCharacterDto Get(string name)
        {
            return _characterService.GetCharacter(name);
        }

        [HttpPost]
        public void Post([FromBody] StarWarsCharacterDto characterDto)
        {
            _characterService.CreateCharacter(characterDto);
        }

        [HttpPut("{name}")]
        public void Put(string name, [FromBody] StarWarsCharacterDto characterDto)
        {
            _characterService.UpdateCharacter(name, characterDto);
        }

        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            _characterService.DeleteCharacter(name);
        }
    }
}
