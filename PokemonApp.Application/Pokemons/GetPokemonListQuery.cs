using MediatR;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Application.Pokemons
{
    public class GetPokemonListQuery : IRequest<IEnumerable<Pokemon>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }

    public class GetPokemonListHandler : IRequestHandler<GetPokemonListQuery, IEnumerable<Pokemon>>
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonListHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public Task<IEnumerable<Pokemon>> Handle(GetPokemonListQuery request, CancellationToken cancellationToken)
        {
            var result = _pokemonService.GetPokemons(request.Page, request.PageSize);

            return Task.FromResult(result);
        }
    }
}
