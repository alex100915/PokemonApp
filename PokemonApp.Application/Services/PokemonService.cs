﻿using PokemonApp.Application.Pokemons;
using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Repositories;

namespace PokemonApp.API.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public Pokemon GetPokemonById(int id)
        {
            return _pokemonRepository.GetPokemonById(id);
        }

        public Pokemon GetPokemonByName(string name)
        {
            return _pokemonRepository.GetPokemonByName(name);
        }

        public IEnumerable<PokemonDto> GetPokemonsForDashboard()
        {
            return _pokemonRepository.GetPokemonsForDashboard();
        }

        public PokemonSummaryData GetPokemonSummary()
        {
            var pokemons = _pokemonRepository.GetPokemonsForDashboard();

            var totalSpecies = pokemons.Count();

            var typesCounts = pokemons
                .SelectMany(p => p.Types)
                .GroupBy(t => t)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToDictionary(g => g.Type, g => g.Count);

            var generationCounts = pokemons
                .GroupBy(p => p.Generation)
                .Select(g => new { Generation = g.Key, Count = g.Count() })
                .ToDictionary(g => g.Generation, g => g.Count);

            return new PokemonSummaryData
            {
                TotalSpecies = totalSpecies,
                TypeCounts = typesCounts,
                GenerationCounts = generationCounts
            };
        }
    }
}
