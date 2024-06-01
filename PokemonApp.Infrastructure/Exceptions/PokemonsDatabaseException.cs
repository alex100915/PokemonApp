using System.Runtime.Serialization;

namespace PokemonApp.Infrastructure.Exceptions
{
    [Serializable]
    public class PokemonsDatabaseException : Exception
    {
        public PokemonsDatabaseException()
        {
        }

        public PokemonsDatabaseException(string? message) : base(message)
        {
        }

        public PokemonsDatabaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PokemonsDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}