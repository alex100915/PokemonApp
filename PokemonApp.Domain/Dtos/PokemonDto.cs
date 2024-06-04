namespace PokemonApp.Domain.Entities
{
    public class PokemonDto
    {
        public int Number { get; set; }

        public string Name { get; set; }
        
        public string Generation { get; set; }
        
        public int Height { get; set; }
        
        public int Weight { get; set; }
        
        public IEnumerable<string> Types { get; set; }        
        
        public int MovesCount { get; set; }
    }
}
