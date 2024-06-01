using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Repositories
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
    }
}