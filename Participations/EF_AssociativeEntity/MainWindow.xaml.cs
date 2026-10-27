using EF_AssociativeEntity.Models;
using Microsoft.EntityFrameworkCore;
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

namespace EF_AssociativeEntity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var db = new DB_128040_practiceContext();

            lstStudents.ItemsSource = db.Students.Include(s => s.Registrations).ThenInclude(r => r.Course).ToList();
        }

        private void lstStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = lstStudents.SelectedItem as Student;

            MessageBox.Show($"{selectedStudent.Registrations.Count} registrations for {selectedStudent.FirstName} {selectedStudent.LastName}");
        }
    }
}