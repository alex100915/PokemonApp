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

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            return await _pokemonRepository.GetPokemonAsync(id);
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync()
        {
            return await _pokemonRepository.GetPokemonsAsync();
        }
    }
}
