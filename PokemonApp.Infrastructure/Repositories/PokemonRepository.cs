using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Data;

namespace PokemonApp.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        public Pokemon GetPokemonById(int id)
        {
            return PokemonsDatabase.Pokemons.FirstOrDefault(p => p.Number == id);
        }

        public Pokemon GetPokemonByName(string name)
        {
            return PokemonsDatabase.Pokemons.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public IEnumerable<Pokemon> GetPokemons(int page, int pageSize)
        {
            return PokemonsDatabase.Pokemons
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            return PokemonsDatabase.Pokemons
                .ToList();
        }
    }
}
