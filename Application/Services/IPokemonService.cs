﻿using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<Pokemon>> GetPokemonsAsync();

        Task<Pokemon> GetPokemonAsync(int id);
    }
}