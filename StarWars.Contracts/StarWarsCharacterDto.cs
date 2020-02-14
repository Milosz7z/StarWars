using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Contracts
{
    public class StarWarsCharacterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Episodes { get; set; }
        public IEnumerable<string> Friends { get; set; }
        public string Planet { get; set; }
    }
}
