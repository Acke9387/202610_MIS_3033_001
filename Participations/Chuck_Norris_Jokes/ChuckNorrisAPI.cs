using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck_Norris_Jokes
{
    public class ChuckNorrisAPI
    {

        public string value { get; set; }

        public string[] categories { get; set; }

        public override string ToString()
        {
            return value;
        }

    }
}
