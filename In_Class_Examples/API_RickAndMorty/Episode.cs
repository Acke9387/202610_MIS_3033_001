using System;
using System.Collections.Generic;
using System.Text;

namespace API_RickAndMorty
{
    public class Episode
    {

        public string name { get; set; }

        public string air_date { get; set; }

        public override string ToString()
        {
            return $"{name} first aired on ({air_date})";
        }
    }
}
