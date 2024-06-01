namespace PokemonAPI.Services
{
    public interface IPokemonService
    {
        IEnumerable<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
    }
}