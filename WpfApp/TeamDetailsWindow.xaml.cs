using System.Windows;
using Data.Models;

namespace WpfApp
{
    public partial class TeamDetailsWindow : Window
    {
        public TeamDetailsWindow(Team team, MatchDetail[] matches)
        {
            InitializeComponent();

            lblName.Content = team.Country;
            lblCode.Content = team.FifaCode;

            int wins = 0, draws = 0, losses = 0, goalsFor = 0, goalsAgainst = 0;

            foreach (var match in matches)
            {
                bool isHome = match.HomeTeam.FifaCode == team.FifaCode;
                var myGoals = isHome ? match.HomeTeamStatistics.Goals : match.AwayTeamStatistics.Goals;
                var oppGoals = isHome ? match.AwayTeamStatistics.Goals : match.HomeTeamStatistics.Goals;

                goalsFor += myGoals;
                goalsAgainst += oppGoals;

                if (myGoals > oppGoals) wins++;
                else if (myGoals == oppGoals) draws++;
                else losses++;
            }

            lblPlayed.Content = matches.Length;
            lblWins.Content = wins;
            lblDraws.Content = draws;
            lblLosses.Content = losses;
            lblGoalsFor.Content = goalsFor;
            lblGoalsAgainst.Content = goalsAgainst;
            lblGoalDiff.Content = goalsFor - goalsAgainst;
        }
    }
}
