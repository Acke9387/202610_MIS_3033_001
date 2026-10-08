using Newtonsoft.Json;
using System.IO;
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

namespace Chuck_Norris_Jokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<ChuckNorrisAPI> jokesList = new List<ChuckNorrisAPI>();
        public MainWindow()
        {
            InitializeComponent();

            using(var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("https://api.chucknorris.io/jokes/categories").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);
                    categories.Insert(0, "all");
                    cboCategory.ItemsSource = categories;
                    cboCategory.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Error fetching categories.");
                }
            }

            GetJoke();
        }

        private void GetJoke(string category = "all")
        {
            string url = "https://api.chucknorris.io/jokes/random";

            if (category != "all")
            {
                url += $"?category={category}";
            }

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    ChuckNorrisAPI joke = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);
                    txtJoke.Text = joke.value;

                    jokesList.Add(joke);
                }
                else
                {
                    txtJoke.Text = "Error fetching joke.";

                }
            }
        }

        private void GetJokeButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = cboCategory.SelectedItem.ToString();
            GetJoke(selectedCategory);
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            string jokesAsJson = JsonConvert.SerializeObject(jokesList, Formatting.Indented);

            File.WriteAllText("jokes.json", jokesAsJson);

            MessageBox.Show("Jokes exported to jokes.json");
        }
    }
}