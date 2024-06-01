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
        public ActionResult<IEnumerable<Pokemon>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var pagedPokemons = _pokemonService.GetPokemons()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return Ok(pagedPokemons);
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> Get(int id)
        {
            var pokemon = _pokemonService.GetPokemon(id);
            
            if (pokemon == null)
                return NotFound();
            
            return Ok(pokemon);
        }
    }
}