using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Data;

namespace PokemonApp.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        public Pokemon GetPokemon(int id)
        {
            return PokemonsDatabase.Pokemons.FirstOrDefault(p => p.Number == id);
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            return PokemonsDatabase.Pokemons.ToList();
        }
    }
}
