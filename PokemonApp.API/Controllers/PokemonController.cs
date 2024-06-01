using Microsoft.AspNetCore.Mvc;
using PokemonApp.API.Services;
using PokemonApp.Domain.Entities;

namespace PokemonApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : BaseController
    {
        private readonly IPokemonService _pokemonService;
        
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            try
            {
                var pagedPokemons = _pokemonService.GetPokemons(page, pageSize);

                return Ok(pagedPokemons);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> Get(int id)
        {
            try
            {
                var pokemon = _pokemonService.GetPokemon(id);

                if (pokemon == null)
                    return NotFound();

                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}