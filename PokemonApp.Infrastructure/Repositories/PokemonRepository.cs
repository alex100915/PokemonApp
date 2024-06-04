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

        public IEnumerable<PokemonDto> GetPokemonsForDashboard()
        {
            return PokemonsDatabase.Pokemons
                .Select(p => new PokemonDto
                {
                    Name = p.Name,
                    Generation = p.Generation,
                    Height = p.Height,
                    MovesCount = p.Moves.Count(),
                    Number = p.Number,
                    Types = p.Types,
                    Weight = p.Weight
                })
                .ToList();
        }
    }
}
