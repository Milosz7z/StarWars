using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain
{
    public class EpisodeEntity
    {
        public Guid Id { get; private set; }
        public string EpisodeName { get; private set; }

        public EpisodeEntity(Guid id, string episodeName)
        {
            Id = id;
            EpisodeName = episodeName;
        }
    }
}
