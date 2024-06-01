namespace PokemonApp.Domain.Entities
{
    public class Pokemon
    {
        public int Number { get; set; }

        public string Name { get; set; }
        
        public string Generation { get; set; }
        
        public int Height { get; set; }
        
        public int Weight { get; set; }
        
        public IEnumerable<string> Types { get; set; }
        
        public IEnumerable<Stat> Stats { get; set; }
        
        public IEnumerable<string> Moves { get; set; }
        
        public IEnumerable<string> Abilities { get; set; }
        
        public Evolution Evolution { get; set; }
        
        public string Image { get; set; }
    }
}
