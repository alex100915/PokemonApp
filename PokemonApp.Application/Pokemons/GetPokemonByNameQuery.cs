using MediatR;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Application.Pokemons
{
    public class GetPokemonByNameQuery : IRequest<Pokemon>
    {
        public string Name { get; set; }
    }

    public class GetPokemonByNameHandler : IRequestHandler<GetPokemonByNameQuery, Pokemon>
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonByNameHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public Task<Pokemon> Handle(GetPokemonByNameQuery request, CancellationToken cancellationToken)
        {
            var result = _pokemonService.GetPokemonByName(request.Name);

            return Task.FromResult(result);
        }
    }
}
