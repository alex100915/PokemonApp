namespace PokemonApp.Application.Pokemons
{
    public class SummaryData
    {
        public int TotalSpecies { get; set; }

        public Dictionary<string, int> TypeCounts { get; set; }
        
        public Dictionary<string, int> GenerationCounts { get; set; }
    }
}
