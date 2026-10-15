using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PokemonInfo pokemonInfo = null;
        bool shouldShowFront = true;

        public MainWindow()
        {
            InitializeComponent();

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=1400").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    PokemonAPI pokemonAPI = JsonConvert.DeserializeObject<PokemonAPI>(json);
                    cboPokemon.ItemsSource = pokemonAPI.results;
                }
            }
        }

        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PokemonResult selectedPokemon = cboPokemon.SelectedItem as PokemonResult;

            if (selectedPokemon != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(selectedPokemon.url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        pokemonInfo = JsonConvert.DeserializeObject<PokemonInfo>(json);
                        txtHeight.Text = pokemonInfo.height.ToString();
                        txtWeight.Text = pokemonInfo.weight.ToString();
                        txtName.Text = pokemonInfo.name;
                        imgPokemon.Source = new BitmapImage(new Uri(pokemonInfo.sprites.front_default));
                        shouldShowFront = false;

                    }

                }
            }
        }

        private void btnToggleImage_Click(object sender, RoutedEventArgs e)
        {
            if (pokemonInfo is not null)
            {
                if (shouldShowFront == true)
                {
                    imgPokemon.Source = new BitmapImage(new Uri(pokemonInfo.sprites.front_default));
                    shouldShowFront = false;

                }
                else
                {
                    imgPokemon.Source = new BitmapImage(new Uri(pokemonInfo.sprites.back_default));
                    shouldShowFront = true;
                }
            }
        }
    }
}