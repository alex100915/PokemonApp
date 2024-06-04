using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Repositories
{
    public interface IPokemonRepository
    {
        IEnumerable<PokemonDto> GetPokemonsForDashboard();

        Pokemon GetPokemonById(int id);

        Pokemon GetPokemonByName(string name);
    }
}