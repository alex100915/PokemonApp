using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Application.Pokemons;

namespace PokemonApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PokemonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemons()
        {
            var pagedPokemons = await _mediator.Send(new GetPokemonListQuery());

            return Ok(pagedPokemons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            var pokemon = await _mediator.Send(new GetPokemonByIdQuery() { Id = id }); 

            if (pokemon == null)
                return NotFound();

            return Ok(pokemon);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetPokemonByName(string name)
        {
            var pokemon = await _mediator.Send(new GetPokemonByNameQuery() { Name = name });
            
            if (pokemon == null) 
                return NotFound();
            
            return Ok(pokemon);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetPokemonSummary()
        {
            var summary = await _mediator.Send(new GetPokemonSummaryQuery());

            return Ok(summary);
        }
    }
}