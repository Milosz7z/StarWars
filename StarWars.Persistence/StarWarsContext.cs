using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StarWars.Domain;

namespace StarWars.Persistence
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext()
        {

        }
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options)
        {

        }

        public DbSet<StarWarsCharacterEntity> StarWarsCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StarWarsCharacterEntity>().HasMany(x => x.Episodes);
            modelBuilder.Entity<StarWarsCharacterEntity>().HasMany(x => x.Friends);
        }
    }
}
