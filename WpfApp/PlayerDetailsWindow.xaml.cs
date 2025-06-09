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

            // ✨ Animacija Fade-in
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);

            // Postavljanje podataka
            txtName.Text = $"Ime: {player.Name}";
            txtNumber.Text = $"Broj: {player.ShirtNumber}";
            txtPosition.Text = $"Pozicija: {player.Position}";
            txtCaptain.Text = player.Captain ? "Kapetan: DA" : "Kapetan: NE";
            string imagePath = $"data/img/{player.Name}.png";
            imgPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/WpfApp;component/Resources/default-player.png"));



            // Dohvaćanje događaja
            var events = isHomeTeam ? match.HomeTeamEvents : match.AwayTeamEvents;

            int goals = events?.Count(e =>
                e.Player?.Trim().ToLower() == player.Name.Trim().ToLower() &&
                (e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty)
            ) ?? 0;

            int yellowCards = events?.Count(e =>
                e.Player?.Trim().ToLower() == player.Name.Trim().ToLower() &&
                (e.TypeOfEvent == TypeOfEvent.YellowCard || e.TypeOfEvent == TypeOfEvent.YellowCardSecond)
            ) ?? 0;

            txtGoals.Text = $"Golovi: {goals}";
            txtYellowCards.Text = $"Žuti kartoni: {yellowCards}";
        }
    }
}
