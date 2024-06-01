using Newtonsoft.Json;
using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Exceptions;

namespace PokemonApp.Infrastructure.Data
{
    public class PokemonsDatabase
    {
        public static IEnumerable<Pokemon> Pokemons { get; private set; }
        
        static PokemonsDatabase()
        {
            try
            {
                using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\pokemon.json"));

                Pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(reader.ReadToEnd());
            }
            catch (Exception ex) 
            {
                throw new PokemonsDatabaseException($"Error occured loading data from Pokemons database. Excepion: {ex.Message}");
            }
        }
    }
}
