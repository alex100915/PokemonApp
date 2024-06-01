using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Repositories;

namespace PokemonApp.API.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public Pokemon GetPokemon(int id)
        {
            return _pokemonRepository.GetPokemon(id);
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            return _pokemonRepository.GetPokemons();
        }
    }
}
