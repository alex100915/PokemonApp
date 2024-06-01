using Microsoft.EntityFrameworkCore;
using PokemonApp.Domain.Entities;
using PokemonApp.Infrastructure.Data;

namespace PokemonApp.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonAppDbContext _context;
        
        public PokemonRepository(PokemonAppDbContext context) 
        {
            _context = context;
        }

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(p => p.Number == id);
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync()
        {
            return await _context.Pokemons.ToListAsync();
        }
    }
}
