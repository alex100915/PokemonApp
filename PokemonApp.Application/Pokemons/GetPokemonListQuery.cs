using MediatR;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Application.Pokemons
{
    public class GetPokemonListQuery : IRequest<IEnumerable<PokemonDto>>
    {
    }

    public class GetPokemonListHandler : IRequestHandler<GetPokemonListQuery, IEnumerable<PokemonDto>>
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonListHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public Task<IEnumerable<PokemonDto>> Handle(GetPokemonListQuery request, CancellationToken cancellationToken)
        {
            var result = _pokemonService.GetPokemonsForDashboard();

            return Task.FromResult(result);
        }
    }
}
