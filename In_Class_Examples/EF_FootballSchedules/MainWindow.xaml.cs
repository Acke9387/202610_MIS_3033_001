using EF_FootballSchedules.Models;
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

namespace EF_FootballSchedules
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
             
            var schedules = db.FootballSchedules.AsNoTracking().ToList();

            foreach (FootballSchedule game in schedules)
            {
                if (!cboSeason.Items.Contains(game.Season.ToString()))
                {
                    cboSeason.Items.Add(game.Season.ToString());
                }

                //if (game.IsHomeGame == true)
                //{
                //    lstHome.Items.Add(game);
                //}
                //else
                //{
                //    lstAway.Items.Add(game);
                //}
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedYear = cboSeason.SelectedItem as string;

            if (selectedYear != null)
            {
                lstAway.Items.Clear();
                lstHome.Items.Clear();
                int year = int.Parse(selectedYear);
                
                var db = new DB_128040_practiceContext();

                var gamesForYear = db.FootballSchedules.AsNoTracking().Where(g => g.Season == year).ToList();

                // Finding a record based on the primary key using Find() method
                var specificGameWithLambda = db.FootballSchedules.Where(g => g.Id == 1).SingleOrDefault();
                var specificGame = db.FootballSchedules.Find(1);

                // Adding a record to the database
                var newGame = new FootballSchedule
                {
                    Season = 2024,
                    Opponent = "New Team",
                    Date = new DateOnly(2024, 9, 1),
                    IsHomeGame = true
                };

                db.FootballSchedules.Add(newGame);
                db.SaveChanges();


                // Updating a record in the database
                var gameToUpdate = db.FootballSchedules.Find(1);

                if (gameToUpdate != null)
                {
                    gameToUpdate.Opponent = "Updated Team";
                    db.SaveChanges();
                }

                // Deleting a record from the database
                var gameToDelete = db.FootballSchedules.Find(2);
                
                if (gameToDelete != null)
                {
                    db.FootballSchedules.Remove(gameToDelete);
                    db.SaveChanges();
                }

                // Find opponents whose names contain the letter "a"
                var opponentsWithA = db.FootballSchedules
                    .Where(g => g.Opponent.Contains("a"))
                    .ToList();

                var opponentsWithUfirst = db.FootballSchedules
                    .Where(g => g.Opponent[0].ToString() == "U")
                    .ToList();


                foreach (var game in gamesForYear)
                {
                    //if (game.Season == year)
                    //{
                        if (game.IsHomeGame == true)
                        {
                            lstHome.Items.Add(game);
                        }
                        else
                        {
                            lstAway.Items.Add(game);
                        }

                    //}
                }

            }
        }
    }
}