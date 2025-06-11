using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
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
                string mode = "api";          // default način učitavanja
                string championship = "men";  // default spol

                // Učitavanje postavki iz wpf_settings.txt
                if (File.Exists("config/wpf_settings.txt"))
                {
                    var lines = File.ReadAllLines("config/wpf_settings.txt");

                    var modeLine = lines.FirstOrDefault(l => l.StartsWith("Mode="));
                    if (modeLine != null)
                        mode = modeLine.Split('=')[1].Trim().ToLower();

                    var champLine = lines.FirstOrDefault(l => l.StartsWith("Championship="));
                    if (champLine != null)
                        championship = champLine.Split('=')[1].Trim().ToLower();
                }

                // Inicijalizacija repozitorija prema načinu i spolu
                _repo = RepoFactory.CreateRepo(mode, championship);

                var teams = await _repo.GetAllTeamsAsync();
                cmbMyTeam.ItemsSource = teams;
                cmbMyTeam.SelectedIndex = -1; // Spriječi auto-odabir

                cmbOpponent.ItemsSource = null;
                cmbOpponent.IsEnabled = false;
                btnTeamDetails.IsEnabled = false;
                btnOpponentDetails.IsEnabled = false;
                lblScore.Content = "0 : 0";

                if (File.Exists(SettingsPath))
                {
                    var lines = File.ReadAllLines(SettingsPath);
                    var favLine = lines.FirstOrDefault(l => l.StartsWith("FavoriteTeam="));
                    if (favLine != null)
                    {
                        _favTeamCode = favLine.Split('=')[1].Trim().ToUpper();
                        var selectedTeam = teams.FirstOrDefault(t => t.FifaCode?.Trim().ToUpper() == _favTeamCode);

                        if (selectedTeam != null)
                        {
                            cmbMyTeam.SelectedItem = selectedTeam;
                        }
                    }
                }
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

                    var opponentCodes = matches
                        .Where(m => !string.IsNullOrWhiteSpace(m.HomeTeam?.FifaCode) &&
                                    !string.IsNullOrWhiteSpace(m.AwayTeam?.FifaCode))
                        .Select(m =>
                            string.Equals(m.HomeTeam.FifaCode.Trim(), _favTeamCode, StringComparison.OrdinalIgnoreCase)
                                ? m.AwayTeam.FifaCode.Trim().ToLower()
                                : m.HomeTeam.FifaCode.Trim().ToLower())
                        .Distinct()
                        .ToList();

                    var teamsDict = allTeams
                        .Where(t => !string.IsNullOrWhiteSpace(t.FifaCode))
                        .ToDictionary(t => t.FifaCode.Trim().ToLower(), t => t);

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

                    _selectedMatch = matches.FirstOrDefault(m =>
                    {
                        var homeCode = m.HomeTeam?.FifaCode?.Trim().ToLower();
                        var awayCode = m.AwayTeam?.FifaCode?.Trim().ToLower();

                        return (homeCode == myTeamCode && awayCode == opponentCode) ||
                               (homeCode == opponentCode && awayCode == myTeamCode);
                    });

                    if (_selectedMatch != null)
                    {

                        bool isMyTeamHome = _selectedMatch.HomeTeam?.FifaCode?.Trim().ToLower() == myTeamCode;

                        int homeGoals = _selectedMatch.HomeTeamEvents?
                            .Count(e => e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty) ?? 0;

                        int awayGoals = _selectedMatch.AwayTeamEvents?
                            .Count(e => e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty) ?? 0;



                        lblScore.Content = isMyTeamHome
                            ? $"{homeGoals} : {awayGoals}"
                            : $"{awayGoals} : {homeGoals}";



                        btnTeamDetails.IsEnabled = true;
                        btnOpponentDetails.IsEnabled = true;

                        ShowStartingEleven(isMyTeamHome);
                    }
                    else
                    {
                        MessageBox.Show("Utakmica nije pronađena.");
                        lblScore.Content = "0 : 0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom dohvaćanja podataka o utakmici: " + ex.Message);
                }
            }
        }



        private void ShowStartingEleven(bool isMyTeamHome)
        {
            spHomeGK.Children.Clear(); spHomeDEF.Children.Clear(); spHomeMID.Children.Clear(); spHomeATT.Children.Clear();
            spAwayGK.Children.Clear(); spAwayDEF.Children.Clear(); spAwayMID.Children.Clear(); spAwayATT.Children.Clear();

            if (isMyTeamHome)
            {
                AddPlayersToPanel(_selectedMatch?.HomeTeamStatistics?.StartingEleven, true);
                AddPlayersToPanel(_selectedMatch?.AwayTeamStatistics?.StartingEleven, false);
            }
            else
            {
                AddPlayersToPanel(_selectedMatch?.AwayTeamStatistics?.StartingEleven, true);
                AddPlayersToPanel(_selectedMatch?.HomeTeamStatistics?.StartingEleven, false);
            }
        }

        private void AddPlayersToPanel(List<StartingEleven>? players, bool isHome)
        {
            if (players == null) return;

            var gk = players.Where(p => p.Position == Position.Goalie).Take(1).ToList();
            var def = players.Where(p => p.Position == Position.Defender).Take(4).ToList();
            var mid = players.Where(p => p.Position == Position.Midfield).Take(3).ToList();
            var att = players.Where(p => p.Position == Position.Forward).Take(3).ToList();

            int total = gk.Count + def.Count + mid.Count + att.Count;

            var all = players.Where(p => p.Position != Position.Goalie).ToList();
            while (total < 11 && all.Count > 0)
            {
                var next = all.First();
                if (!def.Contains(next) && def.Count < 4)
                    def.Add(next);
                else if (!mid.Contains(next) && mid.Count < 3)
                    mid.Add(next);
                else if (!att.Contains(next) && att.Count < 3)
                    att.Add(next);
                all.Remove(next);
                total++;
            }

            void AddToPanel(StackPanel panel, StartingEleven player)
            {
                var control = new PlayerControl(player)
                {
                    Margin = new Thickness(10)
                };

                // 📌 Dodaj klik event koji otvara PlayerDetailsWindow
                control.MouseLeftButtonUp += (s, e) =>
                {
                    var window = new PlayerDetailsWindow(player, _selectedMatch, isHome);
                    window.ShowDialog();
                };

                panel.Children.Add(control);
            }

            foreach (var p in gk) AddToPanel(isHome ? spHomeGK : spAwayGK, p);
            foreach (var p in def) AddToPanel(isHome ? spHomeDEF : spAwayDEF, p);
            foreach (var p in mid) AddToPanel(isHome ? spHomeMID : spAwayMID, p);
            foreach (var p in att) AddToPanel(isHome ? spHomeATT : spAwayATT, p);
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
