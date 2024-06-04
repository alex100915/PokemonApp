using PokemonApp.Application.Pokemons;
using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Services
{
    public interface IPokemonService
    {
        IEnumerable<PokemonDto> GetPokemonsForDashboard();

        Pokemon GetPokemonById(int id);

        Pokemon GetPokemonByName(string name);

        PokemonSummaryData GetPokemonSummary();
    }
}