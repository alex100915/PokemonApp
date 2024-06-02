using PokemonApp.Domain.Entities;

namespace PokemonApp.Infrastructure.Repositories
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetPokemons(int page, int pageSize);
        
        IEnumerable<Pokemon> GetPokemons();

        Pokemon GetPokemonById(int id);

        Pokemon GetPokemonByName(string name);
    }
}