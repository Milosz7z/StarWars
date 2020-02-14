using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StarWarsContext _starWarsContext;

        public UnitOfWork(StarWarsContext context)
            => _starWarsContext = context;

        public void Commit() => _starWarsContext.SaveChanges();
    }
}
