﻿namespace PokemonApp.Domain.Entities
{
    public class Evolution
    {
        public string From { get; set; }

        public IEnumerable<string> To { get; set; }
    }
}
