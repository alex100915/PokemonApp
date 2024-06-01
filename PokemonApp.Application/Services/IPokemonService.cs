using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Services
{
    public interface IPokemonService
    {
        IEnumerable<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
    }
}