using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class RankingsForm : Form
    {
        private List<MatchDetail> matches;
        private string fifaCode;
        private string countryName;
        private PrintDocument printDocument;
        private string printContent;

        public RankingsForm(List<MatchDetail> matches, string countryName)
        {
            InitializeComponent();
            this.matches = matches;
            this.countryName = countryName;
            LoadRankings();
        }

        private void LoadRankings()
        {
           

            // 1. Golovi
            var goalEvents = matches
                .Where(m => m.HomeTeamCountry == countryName || m.AwayTeamCountry == countryName)
                .SelectMany(m => m.HomeTeamCountry == countryName ? m.HomeTeamEvents : m.AwayTeamEvents)
                .Where(e => e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty)
                .GroupBy(e => e.Player)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count);

            flpGoals.Controls.Clear();
            foreach (var playerStat in goalEvents)
            {
                var player = FindPlayer(playerStat.Name);
                if (player == null) continue;

                var ctrl = new PlayerControl(player);
                ctrl.SetStatValue(playerStat.Count.ToString());
                flpGoals.Controls.Add(ctrl);
            }

            // 2. Žuti kartoni
            var yellowEvents = matches
                .Where(m => m.HomeTeamCountry == countryName || m.AwayTeamCountry == countryName)
                .SelectMany(m => m.HomeTeamCountry == countryName ? m.HomeTeamEvents : m.AwayTeamEvents)
                .Where(e => e.TypeOfEvent == TypeOfEvent.YellowCard)
                .GroupBy(e => e.Player)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count);

            flpCards.Controls.Clear();
            foreach (var playerStat in yellowEvents)
            {
                var player = FindPlayer(playerStat.Name);
                if (player == null) continue;

                var ctrl = new PlayerControl(player);
                ctrl.SetStatValue(playerStat.Count.ToString());
                flpCards.Controls.Add(ctrl);
            }

            // 3. Gledatelji
            var attendanceMatches = matches
                .Where(m => m.HomeTeamCountry == countryName || m.AwayTeamCountry == countryName)
                .OrderByDescending(m => m.Attendance);

            flpAttendance.Controls.Clear();
            foreach (var match in attendanceMatches)
            {
                var ctrl = new AttendanceControl(
                    match.Location,
                    (int)match.Attendance,
                    match.HomeTeamCountry,
                    match.AwayTeamCountry
                );
                flpAttendance.Controls.Add(ctrl); 
            }
        }

        private StartingEleven FindPlayer(string name)
        {
            foreach (var match in matches)
            {
                TeamStatistics? teamStats = null;

                if (match.HomeTeamCountry == countryName)
                    teamStats = match.HomeTeamStatistics;
                else if (match.AwayTeamCountry == countryName)
                    teamStats = match.AwayTeamStatistics;

                if (teamStats == null) continue;

                var player = teamStats.StartingEleven.Concat(teamStats.Substitutes)
                    .FirstOrDefault(p => p.Name == name);

                if (player != null)
                    return player;
            }

            return null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            printContent = GeneratePrintableContent();

            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
            {
                previewDialog.Document = printDocument;
                previewDialog.Width = 1000;
                previewDialog.Height = 800;
                previewDialog.ShowDialog();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(printContent, new Font("Segoe UI", 10), Brushes.Black,
                new RectangleF(50, 50, e.MarginBounds.Width, e.MarginBounds.Height));
        }

        private string GeneratePrintableContent()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" RANK LIST OF PLAYERS AND GAMES");
            sb.AppendLine();

            sb.AppendLine(" Most goals:");
            foreach (PlayerControl pc in flpGoals.Controls)
            {
                sb.AppendLine($"- {pc.PlayerData.Name} ({pc.StatValue} goals)");
            }

            sb.AppendLine();
            sb.AppendLine(" Most yellow cards:");
            foreach (PlayerControl pc in flpCards.Controls)
            {
                sb.AppendLine($"- {pc.PlayerData.Name} ({pc.StatValue} yellow cards)");
            }

            sb.AppendLine();
            sb.AppendLine(" Biggest attendance:");
            foreach (AttendanceControl ac in flpAttendance.Controls)
            {
                sb.AppendLine($"- {ac.Controls["lblLocation"].Text} | {ac.Controls["lblAttendance"].Text} | {ac.Controls["lblTeams"].Text}");
            }

            return sb.ToString();
        }

        private void flpGoals_Paint(object sender, PaintEventArgs e) { }
        private void flpCards_Paint(object sender, PaintEventArgs e) { }
        private void flpAttendance_Paint(object sender, PaintEventArgs e) { }

        private void lblCards_Click(object sender, EventArgs e)
        {

        }
        private void lblAttendance_Click(object sender, EventArgs e)
        {

        }
    }
}
