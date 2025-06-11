using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Data.Enums;
using Data.Models;

namespace WpfApp
{
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow(StartingEleven player, MatchDetail match, bool isHomeTeam)
        {
            InitializeComponent();

            //  Animacija Fade-in
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);

            // Postavljanje osnovnih podataka
            txtName.Text = $"Ime: {player.Name}";
            txtNumber.Text = $"Broj: {player.ShirtNumber}";
            txtPosition.Text = $"Pozicija: {player.Position}";
            txtCaptain.Text = player.Captain ? "Kapetan: DA" : "Kapetan: NE";

            // Slika igrača (default ako ne postoji)
            string imagePath = $"data/img/{player.Name}.png";
            imgPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/WpfApp;component/Resources/default-player.png"));

            //  UZMI SVE DOGAĐAJE iz obje ekipe
            var allEvents = match.HomeTeamEvents.Concat(match.AwayTeamEvents);

            //  Pametna usporedba imena (zbog dijakritike, razlika u unosu itd.)
            bool IsSamePlayer(string evPlayer, string selectedPlayer)
            {
                return evPlayer?.Trim().ToLower().Contains(selectedPlayer.Trim().ToLower()) == true ||
                       selectedPlayer.Trim().ToLower().Contains(evPlayer?.Trim().ToLower());
            }

            //  Zbrajanje golova i kartona iz svih događaja
            int goals = allEvents.Count(e =>
                e.Player != null &&
                IsSamePlayer(e.Player, player.Name) &&
                (e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty)
            );

            int yellowCards = allEvents.Count(e =>
                e.Player != null &&
                IsSamePlayer(e.Player, player.Name) &&
                (e.TypeOfEvent == TypeOfEvent.YellowCard || e.TypeOfEvent == TypeOfEvent.YellowCardSecond)
            );

            txtGoals.Text = $"Golovi: {goals}";
            txtYellowCards.Text = $"Žuti kartoni: {yellowCards}";
        }

    }
}
