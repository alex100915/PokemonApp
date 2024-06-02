using MediatR;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Application.Pokemons
{
    public class GetPokemonSummaryQuery : IRequest<SummaryData>
    {
    }

    public class GetPokemonSummaryHandler : IRequestHandler<GetPokemonSummaryQuery, SummaryData>
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonSummaryHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public Task<SummaryData> Handle(GetPokemonSummaryQuery request, CancellationToken cancellationToken)
        {
            var result = _pokemonService.GetPokemonSummary();

            return Task.FromResult(result);
        }
    }
}
