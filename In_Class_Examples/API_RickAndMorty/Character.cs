namespace API_RickAndMorty
{
    public class Character
    {

        public int id { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public List<string> episode { get; set; }

        public Character()
        {
            id = 0;
            name = string.Empty;
            image = string.Empty;
            episode = new List<string>();
        }

        public override string ToString()
        {
            return name;
        }

    }
}