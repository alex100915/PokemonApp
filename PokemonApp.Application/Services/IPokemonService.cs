using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Services
{
    public interface IPokemonService
    {
        IEnumerable<Pokemon> GetPokemons(int page, int pageSize);

        Pokemon GetPokemon(int id);
    }
}