using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonAPI.Models;

namespace PokemonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private static readonly List<Pokemon> Pokemons;

        static PokemonController()
        {
            using var reader = new StreamReader("pokemon.json");
            var json = reader.ReadToEnd();
            Pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> GetPokemons([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var pagedPokemons = Pokemons.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(pagedPokemons);
        }

        [HttpGet("{number}")]
        public ActionResult<Pokemon> GetPokemon(int number)
        {
            var pokemon = Pokemons.FirstOrDefault(p => p.Number == number);
            if (pokemon == null)
                return NotFound();
            return Ok(pokemon);
        }
    }
}