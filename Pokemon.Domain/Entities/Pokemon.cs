namespace Pokemon.Domain.Entities
{
    public class Pokemon
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Generation { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<string> Types { get; set; }
        public List<Stat> Stats { get; set; }
        public List<string> Moves { get; set; }
        public List<string> Abilities { get; set; }
        public Evolution Evolution { get; set; }
        public string Image { get; set; }
    }
}
