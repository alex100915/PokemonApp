using Newtonsoft.Json;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Data
{
    public class PokemonsDatabase
    {
        public static readonly IEnumerable<Pokemon> Pokemons;
        
        static PokemonsDatabase()
        {
            using var reader = new StreamReader("pokemon.json");
            var json = reader.ReadToEnd();

            Pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);
        }
    }
}
