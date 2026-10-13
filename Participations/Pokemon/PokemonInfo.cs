using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    public class PokemonInfo
    {

        public string name { get; set; }
        public int id { get; set; }

        public int height { get; set; }

        public int weight { get; set; }

        public Sprite sprites { get; set; }

        public PokemonInfo()
        {
            name = string.Empty;
            id = 0;
            height = 0;
            weight = 0;
            sprites = new Sprite();
        }
    }
}
