namespace Pokemon
{
    public class PokemonResult
    {

        public string name { get; set; }
        public string url { get; set; }
        public PokemonResult()
        {
            name = string.Empty;
            url = string.Empty;
        }

        public override string ToString()
        {
            return name;
        }
    }
}