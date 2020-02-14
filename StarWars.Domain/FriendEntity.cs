using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Domain
{
    public class FriendEntity
    {
        public Guid Id { get; private set; }
        public string FriendName { get; private set; }

        public FriendEntity(Guid id, string friendName)
        {
            Id = id;
            FriendName = friendName;
        }
    }
}
