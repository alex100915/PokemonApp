using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Application.Pokemons;

namespace PokemonApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : BaseController
    {
        private readonly IMediator _mediator;

        public PokemonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemons([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            try
            {
                var pagedPokemons = await _mediator.Send(new GetPokemonListQuery() { Page = page, PageSize = pageSize });

                return Ok(pagedPokemons);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            try
            {
                var pokemon = await _mediator.Send(new GetPokemonByIdQuery() { Id = id }); 

                if (pokemon == null)
                    return NotFound();

                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
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