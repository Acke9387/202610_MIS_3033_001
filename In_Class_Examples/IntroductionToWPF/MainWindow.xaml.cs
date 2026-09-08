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

namespace IntroductionToWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> all_Foods = new List<string>();
        string favoriteFood;

        public MainWindow()
        {
            InitializeComponent();
            string[] foods = File.ReadAllLines("sales.csv");

            foreach (string food in foods.Skip(1))
            {
                lstFoods.Items.Add(food);
                all_Foods.Add(food);
            }
            favoriteFood = "Steak";
            txtFood.Clear();
            txtFood.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Button clicked");
            string foodName = txtFood.Text;
            if (foodName!= "" || foodName.Length > 2)
            {
                lstFoods.Items.Add(foodName); 
            }
            txtFood.Text = "";
            txtFood.Clear();    
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show("Text changed", "User Message", MessageBoxButton.CancelTryContinue, MessageBoxImage.Warning);
            
        }
    }
}