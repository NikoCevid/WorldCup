using System.Linq;
using System.Windows;
using Data.Enums;
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
                bool isHome = match.HomeTeam?.FifaCode?.Trim().ToUpper() == team.FifaCode?.Trim().ToUpper();
                bool isAway = match.AwayTeam?.FifaCode?.Trim().ToUpper() == team.FifaCode?.Trim().ToUpper();
                if (!isHome && !isAway) continue;

                int homeGoals = match.HomeTeamEvents?.Count(e =>
                    e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty) ?? 0;

                int awayGoals = match.AwayTeamEvents?.Count(e =>
                    e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty) ?? 0;

                int myGoals = isHome ? homeGoals : awayGoals;
                int oppGoals = isHome ? awayGoals : homeGoals;

                goalsFor += myGoals;
                goalsAgainst += oppGoals;

                if (myGoals > oppGoals) wins++;
                else if (myGoals == oppGoals) draws++;
                else losses++;
            }

            int played = matches.Count(m =>
     m.HomeTeam?.FifaCode?.Trim().ToUpper() == team.FifaCode?.Trim().ToUpper() ||
     m.AwayTeam?.FifaCode?.Trim().ToUpper() == team.FifaCode?.Trim().ToUpper());

            lblPlayed.Content = played;

            lblWins.Content = wins;
            lblDraws.Content = draws;
            lblLosses.Content = losses;
            lblGoalsFor.Content = goalsFor;
            lblGoalsAgainst.Content = goalsAgainst;
            lblGoalDiff.Content = goalsFor - goalsAgainst;
        }
    }
}
