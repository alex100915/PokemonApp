using Microsoft.AspNetCore.Mvc;
using PokemonApp.Infrastructure.Exceptions;
using System.Net;

namespace PokemonApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummaryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSummary()
        {
            return Ok(new SummaryData { TotalSpecies=5 , TypeCounts = new Dictionary<string, int>(), GenerationCounts = new Dictionary<string, int>() });
        }
    }
    public class SummaryData
    {
        public int TotalSpecies { get; set; }
        public Dictionary<string, int> TypeCounts { get; set; }
        public Dictionary<string, int> GenerationCounts { get; set; }
    }
}