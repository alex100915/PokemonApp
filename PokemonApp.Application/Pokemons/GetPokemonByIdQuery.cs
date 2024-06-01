using MediatR;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Application.Pokemons
{
    public class GetPokemonByIdQuery : IRequest<Pokemon>
    {
        public int Id { get; set; }
    }

    public class GetPokemonByIdHandler : IRequestHandler<GetPokemonByIdQuery, Pokemon>
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonByIdHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public Task<Pokemon> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _pokemonService.GetPokemon(request.Id);

            return Task.FromResult(result);
        }
    }
}
