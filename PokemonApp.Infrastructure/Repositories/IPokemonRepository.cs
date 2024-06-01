using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Repositories
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetPokemons(int page, int pageSize);

        Pokemon GetPokemon(int id);
    }
}