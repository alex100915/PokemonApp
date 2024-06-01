using Microsoft.AspNetCore.Mvc;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var pagedPokemons = (await _pokemonService.GetPokemonsAsync()).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(pagedPokemons);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<Pokemon>> Get(int number)
        {
            var pokemon = await _pokemonService.GetPokemonAsync(number);
            if (pokemon == null)
                return NotFound();
            return Ok(pokemon);
        }
    }
}