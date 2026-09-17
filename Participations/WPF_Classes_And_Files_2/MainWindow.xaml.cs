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

namespace WPF_Classes_And_Files_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Sale> salesList = new List<Sale>();

        public MainWindow()
        {
            InitializeComponent();

            string[] linesOfFile = File.ReadAllLines("SalesJan2009.csv");
            for (int i = 1; i < linesOfFile.Length; i++)
            {
                //       0            1      2          3      4    5      6     7           8            9         10       11
                //Transaction_date,Product,Price,Payment_Type,Name,City,State,Country,Account_Created,Last_Login,Latitude,Longitude
                string line = linesOfFile[i];
                //line = "1/2/09 6:17,Product1,1200,Mastercard,carolina,Basildon,England,United Kingdom,1/2/09 6:00,1/2/09 6:08,51.5,-1.1166667"
                string[] partsOfLine = linesOfFile[i].Split(',');
                Sale sale = new Sale();
                sale.TransactionDate = DateTime.Parse(partsOfLine[0].Trim());
                sale.Price = double.Parse(partsOfLine[2].Trim());
                sale.PaymentType = partsOfLine[3].Trim();
                sale.Name = partsOfLine[4].Trim();
                sale.Country = partsOfLine[7].Trim();
                salesList.Add(sale);
            }

            PopulateListBox("Amex");
            PopulateListBox("Visa");
            PopulateListBox("Mastercard");
            PopulateListBox("Diners");

        }

        private void PopulateListBox(string paymentType)
        {
            foreach (Sale s in salesList)
            {

                if (paymentType.ToLower() == "amex")
                {
                    if (s.PaymentType.ToLower() == "amex")
                    {
                        lstAmex.Items.Add(s);
                    }
                }
                else if (paymentType.ToLower() == "visa")
                {
                    if (s.PaymentType.ToLower() == "visa")
                    {
                        lstVisa.Items.Add(s);
                    }
                }
                else if (paymentType.ToLower() == "diners")
                {
                    if (s.PaymentType.ToLower() == "diners")
                    {
                        lstDiners.Items.Add(s);
                    }
                }
                else if (paymentType.ToLower() == "mastercard")
                {
                    if (s.PaymentType.ToLower() == "mastercard")
                    {
                        lstMastercard.Items.Add(s);
                    }
                }
            }
        }
    }
}