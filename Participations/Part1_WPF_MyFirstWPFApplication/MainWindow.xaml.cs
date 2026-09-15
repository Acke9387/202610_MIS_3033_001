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
        List<Product> filteredProducts = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();

            // Read in the data file and populate the listbox
            string jsonFromFile = File.ReadAllText("products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonFromFile);

            foreach (Product product in products)
            {
                lstProducts.Items.Add(product);
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get the values from the textboxes and create a new object to add to the listbox
            Product newProduct = new Product();
            newProduct.Name = txtName.Text;
            newProduct.Category = txtCategory.Text;
            newProduct.Price = double.Parse(txtPrice.Text);

            lstProducts.Items.Add(newProduct);

            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            // Get all the products from the listbox and serialize them to a file

            string jsonToWriteToFile = JsonConvert.SerializeObject(lstProducts.Items, Formatting.Indented);

            File.WriteAllText("products-export.json", jsonToWriteToFile);

            MessageBox.Show("Products exported to products-export.json");
        }
    }
}