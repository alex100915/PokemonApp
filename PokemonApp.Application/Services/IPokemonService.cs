using PokemonApp.Application.Pokemons;
using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Services
{
    public interface IPokemonService
    {
        IEnumerable<Pokemon> GetPokemons(int page, int pageSize);

        Pokemon GetPokemonById(int id);

        Pokemon GetPokemonByName(string name);

        SummaryData GetPokemonSummary();
    }
}