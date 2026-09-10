using Newtonsoft.Json;
using System.IO;
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

namespace Part1_WPF_MyFirstWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Read in the data file and populate the listbox
            string jsonFromFile = File.ReadAllText("products.json");


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get the values from the textboxes and create a new object to add to the listbox


        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            // Get all the products from the listbox and serialize them to a file

            string jsonToWriteToFile = JsonConvert.SerializeObject(lstProducts.Items, Formatting.Indented);


        }
    }
}