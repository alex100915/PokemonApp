using MediatR;
using PokemonApp.API.Services;

namespace PokemonApp.Application.Pokemons
{
    public class GetPokemonSummaryQuery : IRequest<PokemonSummaryData>
    {
    }

    public class GetPokemonSummaryHandler : IRequestHandler<GetPokemonSummaryQuery, PokemonSummaryData>
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonSummaryHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public Task<PokemonSummaryData> Handle(GetPokemonSummaryQuery request, CancellationToken cancellationToken)
        {
            var result = _pokemonService.GetPokemonSummary();

            return Task.FromResult(result);
        }
    }
}
