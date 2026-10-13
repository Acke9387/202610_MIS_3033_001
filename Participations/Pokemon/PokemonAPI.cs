using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class PokemonAPI
    {

        public List<PokemonResult> results { get; set; }

        public PokemonAPI()
        {
            results = new List<PokemonResult>();
        }

    }
}
