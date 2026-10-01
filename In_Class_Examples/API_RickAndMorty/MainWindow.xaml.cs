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

namespace API_RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Character> characters = new List<Character>();
        public MainWindow()
        {
            InitializeComponent();

            // old way with a file
            //string fileAsJson = File.ReadAllText("rickandmorty.json");

            string url = "https://rickandmortyapi.com/api/character";
            using (HttpClient client = new HttpClient())
            {
                bool hasNextPage = true;
                while (hasNextPage == true)
                {
                    RickAndMortyAPI api = new RickAndMortyAPI();
                    string json = client.GetStringAsync(url).Result;
                    api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);
                    foreach (Character item in api.results)
                    {
                        characters.Add(item);
                    }
                    if (api.info.next != null)
                    {
                        url = api.info.next;
                    }
                    else
                    {
                        hasNextPage = false;
                    }
                }
            }

            cboCharacters.ItemsSource = characters;

            //old way
            //HttpClient client = new HttpClient();
            //string json = client.GetStringAsync(url).Result;
            //client.Dispose();


            //RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selectedCharacter = (Character)cboCharacters.SelectedItem;

            if (selectedCharacter != null)
            {
                lblName.Content = selectedCharacter.name;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedCharacter.image, UriKind.Absolute);
                bitmap.EndInit();
                imgCharacter.Source = bitmap;

                lblName.Visibility = Visibility.Visible;

                lstEpisodes.Items.Clear();
                foreach (string episode in selectedCharacter.episode)
                {
                    lstEpisodes.Items.Add(episode);
                }
            }
        }

        private void lstEpisodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedEpisodeUrl = (string)lstEpisodes.SelectedItem;

            if (!string.IsNullOrEmpty(selectedEpisodeUrl))
            {
                using (HttpClient client = new HttpClient())
                {
                    string episodeJson = client.GetStringAsync(selectedEpisodeUrl).Result;
                    Episode episode = JsonConvert.DeserializeObject<Episode>(episodeJson);
                    MessageBox.Show(episode.ToString(), "Episode Details", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
    }
}