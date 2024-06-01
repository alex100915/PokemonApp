using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Repositories
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetPokemonsAsync();

        Task<Pokemon> GetPokemonAsync(int id);
    }
}