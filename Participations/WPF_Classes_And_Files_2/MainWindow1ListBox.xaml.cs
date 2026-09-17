using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Classes_And_Files_2
{
    /// <summary>
    /// Interaction logic for MainWindow1ListBox.xaml
    /// </summary>
    public partial class MainWindow1ListBox : Window
    {
        List<Sale> salesList = new List<Sale>();
        public MainWindow1ListBox()
        {
            InitializeComponent();
            string[] linesOfFile = File.ReadAllLines("SalesJan2009.csv");
            cboPaymentTypes.Items.Add("All");

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

                if (cboPaymentTypes.Items.Contains(sale.PaymentType) == false)
                {
                    cboPaymentTypes.Items.Add(sale.PaymentType);
                }

                salesList.Add(sale);
            }

            PopulateListBox("All");
        }

        private void PopulateListBox(string paymentType)
        {
            lstSales.Items.Clear();
            foreach (Sale s in salesList)
            {
                if(paymentType.ToLower() == "all" || s.PaymentType == paymentType)
                {
                    lstSales.Items.Add(s);
                }
            }
        }

        private void cboPaymentTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPaymentType = cboPaymentTypes.SelectedItem.ToString();

            PopulateListBox(selectedPaymentType);
        }
    }
}
