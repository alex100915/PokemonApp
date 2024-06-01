using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokemonApp.Domain.Entities;
using System.IO;

namespace PokemonApp.Infrastructure.Data
{
    public class PokemonAppDbContext : DbContext
    {
        public PokemonAppDbContext(DbContextOptions<PokemonAppDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Evolution>().HasNoKey();
            
            modelBuilder.Entity<Pokemon>().HasData(() =>
            {
                using var reader = new StreamReader("pokemon.json");
                var json = reader.ReadToEnd();
                
                return JsonConvert.DeserializeObject<Pokemon>(json);
            });
        }
    }
}
