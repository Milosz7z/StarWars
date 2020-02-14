using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Persistence
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
