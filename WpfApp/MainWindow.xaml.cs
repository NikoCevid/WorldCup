using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Data;
using Data.Enums;
using Data.Models;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private IRepo _repo;
        private string _favTeamCode = string.Empty;
        private MatchDetail? _selectedMatch;
        private const string SettingsPath = "settings.txt";

        public MainWindow()
        {
            InitializeComponent();
            _repo = RepoFactory.CreateRepo();

            this.Loaded += async (_, __) => await LoadAsync();
        }

        private async Task LoadAsync()
        {
            try
            {
                var teams = await _repo.GetAllTeamsAsync();
                cmbMyTeam.ItemsSource = teams;
                cmbOpponent.IsEnabled = false;
                btnTeamDetails.IsEnabled = false;
                btnOpponentDetails.IsEnabled = false;

                if (File.Exists(SettingsPath))
                {
                    var lines = File.ReadAllLines(SettingsPath);
                    var favLine = lines.FirstOrDefault(l => l.StartsWith("FavoriteTeam="));
                    if (favLine != null)
                    {
                        _favTeamCode = favLine.Split('=')[1].Trim();
                        cmbMyTeam.SelectedItem = teams.FirstOrDefault(t => t.FifaCode?.Trim() == _favTeamCode);
                    }
                }
              

                cmbMyTeam.ItemsSource = teams;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju reprezentacija: " + ex.Message);
            }
        }

        
        private async void cmbMyTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMyTeam.SelectedItem is Team myTeam)
            {
                _favTeamCode = myTeam.FifaCode?.Trim() ?? string.Empty;

                try
                {
                    var matches = await _repo.GetMatchDetailsAsync(_favTeamCode);
                    var allTeams = await _repo.GetAllTeamsAsync();

                    var debugMatches = matches.Select(m =>
                        $"{m.HomeTeam?.FifaCode} vs {m.AwayTeam?.FifaCode}");

                    var opponentCodes = matches
                        .Where(m =>
                            !string.IsNullOrWhiteSpace(m.HomeTeam?.FifaCode) &&
                            !string.IsNullOrWhiteSpace(m.AwayTeam?.FifaCode))
                        .Select(m =>
                            string.Equals(m.HomeTeam.FifaCode.Trim(), _favTeamCode, StringComparison.OrdinalIgnoreCase)
                                ? m.AwayTeam.FifaCode.Trim().ToLower()
                                : m.HomeTeam.FifaCode.Trim().ToLower())
                        .Where(code => !string.IsNullOrWhiteSpace(code))
                        .Distinct()
                        .ToList();

                    var kodoviUTimovima = allTeams
                        .Where(t => !string.IsNullOrWhiteSpace(t.FifaCode))
                        .Select(t => t.FifaCode.Trim().ToLower())
                        .ToList();
                    var teamsDict = allTeams
                        .Where(t => !string.IsNullOrWhiteSpace(t.FifaCode))
                        .ToDictionary(t => t.FifaCode.Trim().ToLower(), t => t);

                    // Izvuci samo one timove koji postoje
                    var opponentTeams = opponentCodes
                        .Where(code => teamsDict.ContainsKey(code))
                        .Select(code => teamsDict[code])
                        .ToList();

                    cmbOpponent.ItemsSource = opponentTeams;
                    cmbOpponent.SelectedItem = null;
                    cmbOpponent.IsEnabled = opponentTeams.Any();
                    btnOpponentDetails.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom dohvaćanja protivnika: " + ex.Message);
                }
            }
        }



        private async void cmbOpponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMyTeam.SelectedItem is Team myTeam && cmbOpponent.SelectedItem is Team opponent)
            {
                var myTeamCode = myTeam.FifaCode?.Trim().ToLower() ?? string.Empty;
                var opponentCode = opponent.FifaCode?.Trim().ToLower() ?? string.Empty;

                try
                {
                    var matches = await _repo.GetMatchDetailsAsync(myTeam.FifaCode);


                    var allMatchCodes = matches.Select(m =>
                        $"{m.HomeTeam?.FifaCode?.ToLower()} vs {m.AwayTeam?.FifaCode?.ToLower()}");


                    _selectedMatch = matches.FirstOrDefault(m =>
                    {
                        var homeCode = m.HomeTeam?.FifaCode?.Trim().ToLower();
                        var awayCode = m.AwayTeam?.FifaCode?.Trim().ToLower();

                        return (homeCode == myTeamCode && awayCode == opponentCode) ||
                               (homeCode == opponentCode && awayCode == myTeamCode);
                    });

                    if (_selectedMatch != null)
                    {
                        int homeGoals = _selectedMatch.HomeTeamStatistics?.Goals ?? 0;
                        int awayGoals = _selectedMatch.AwayTeamStatistics?.Goals ?? 0;

                        lblScore.Content = $"{homeGoals} : {awayGoals}";
                        btnTeamDetails.IsEnabled = true;
                        btnOpponentDetails.IsEnabled = true;

                        ShowStartingEleven();
                    }
                    else
                    {
                        MessageBox.Show("Utakmica nije pronađena.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom dohvaćanja podataka o utakmici: " + ex.Message);
                }
            }
        }

        private void ShowStartingEleven()
        {
            canvasPlayers.Children.Clear();

            var home = _selectedMatch?.HomeTeamStatistics?.StartingEleven;
            if (home != null && home.Any()) AddPlayersToSide(home, true);

            var away = _selectedMatch?.AwayTeamStatistics?.StartingEleven;
            if (away != null && away.Any()) AddPlayersToSide(away, false);
        }

        private void AddPlayersToSide(List<StartingEleven> players, bool isLeft)
        {
            var posGroups = new[] { Position.Goalie, Position.Defender, Position.Midfield, Position.Forward };

            double canvasWidth = canvasPlayers.ActualWidth;
            double totalHeight = 500;
            double rowHeight = totalHeight / posGroups.Length;

            for (int row = 0; row < posGroups.Length; row++)
            {
                var group = players.Where(p => p.Position == posGroups[row]).ToList();
                int count = group.Count;
                double y = row * rowHeight + 20;

                for (int i = 0; i < count; i++)
                {
                    var player = group[i];
                    var control = new PlayerControl(player);

                    double spacing = canvasWidth / (count + 1);
                    double x = spacing * (i + 1);
                    if (!isLeft) x = canvasWidth - x;

                    Canvas.SetLeft(control, x - control.Width / 2);
                    Canvas.SetTop(control, y);
                    canvasPlayers.Children.Add(control);

                    AnimateFadeIn(control);
                }
            }
        }

        private void AnimateFadeIn(UIElement element, double durationSeconds = 0.3)
        {
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationSeconds)
            };
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private async void btnTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMyTeam.SelectedItem is Team myTeam)
            {
                var matches = await _repo.GetMatchDetailsAsync(myTeam.FifaCode);
                var detailsWindow = new TeamDetailsWindow(myTeam, matches.ToArray());
                AnimateOpen(detailsWindow);
            }
        }

        private async void btnOpponentDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOpponent.SelectedItem is Team opponent)
            {
                var matches = await _repo.GetMatchDetailsAsync(opponent.FifaCode);
                var detailsWindow = new TeamDetailsWindow(opponent, matches.ToArray());
                AnimateOpen(detailsWindow);
            }
        }

        private void AnimateOpen(Window window)
        {
            window.Opacity = 0;
            window.Show();
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            window.BeginAnimation(Window.OpacityProperty, fadeIn);
        }
    }
}
