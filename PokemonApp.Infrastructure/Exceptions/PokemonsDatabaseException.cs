namespace PokemonApp.Infrastructure.Exceptions
{
    [Serializable]
    public class PokemonsDatabaseException : Exception
    {
        public PokemonsDatabaseException(string? message) : base(message)
        {
        }
    }
}