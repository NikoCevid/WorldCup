using Data;
using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Helpers;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private IRepo repo;
        private string selectedFifaCode;
        private const string SettingsFile = "settings.txt";
        private const string FavPlayersFile = "favPlayers.txt";
        private List<MatchDetail> matchList;
        private StartingEleven selectedPlayer;

        public MainForm()
        {
            InitializeComponent();

            pnlPlayers.AllowDrop = true;
            pnlPlayers.DragEnter += Panel_DragEnter;
            pnlPlayers.DragDrop += Panel_DragDrop;

            pnlFavPlayers.AllowDrop = true;
            pnlFavPlayers.DragEnter += Panel_DragEnter;
            pnlFavPlayers.DragDrop += Panel_DragDrop;


            LoadAsync();
        }


        private async void LoadAsync()
        {
            repo = RepoFactory.CreateRepo();
            await LoadMatchDataAsync();
            await LoadTeamsAsync();
            LoadFavPlayers();
        }

        private async Task LoadMatchDataAsync()
        {
            matchList = await repo.GetAllMatchDetailsAsync();
        }

        private async Task LoadTeamsAsync()
        {
            var teams = await repo.GetAllTeamsAsync();
            cmbRepresentation.Items.Clear();

            foreach (var team in teams.OrderBy(t => t.Country))
            {
                cmbRepresentation.Items.Add($"{team.Country} ({team.FifaCode})");
            }

            LoadFavouriteTeam();
        }

        private void LoadFavouriteTeam()
        {
            if (File.Exists(SettingsFile))
            {
                selectedFifaCode = File.ReadAllText(SettingsFile);
                var item = cmbRepresentation.Items
                    .Cast<string>()
                    .FirstOrDefault(i => i.Contains($"({selectedFifaCode})"));

                if (item != null)
                {
                    cmbRepresentation.SelectedItem = item;
                }
            }
        }

        private async void cmbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRepresentation.SelectedItem == null) return;

            var selectedText = cmbRepresentation.SelectedItem.ToString();
            selectedFifaCode = selectedText.Substring(selectedText.LastIndexOf('(') + 1, 3);
            File.WriteAllText(SettingsFile, selectedFifaCode);

            var teams = await repo.GetAllTeamsAsync();
            var selectedCountry = teams.FirstOrDefault(t => t.FifaCode == selectedFifaCode)?.Country;
            if (selectedCountry == null) return;

            var teamMatches = matchList
            .Where(m => m.HomeTeamCountry == selectedCountry || m.AwayTeamCountry == selectedCountry)
            .ToList();

            var players = new List<StartingEleven>();

            foreach (var match in teamMatches)
            {
                var teamStats = match.HomeTeamCountry == selectedCountry
                    ? match.HomeTeamStatistics
                    : match.AwayTeamStatistics;

                players.AddRange(teamStats.StartingEleven);
                players.AddRange(teamStats.Substitutes);
            }

            
            players = players
                .GroupBy(p => p.Name)
                .Select(g => g.First())
                .ToList();

            Debug.WriteLine($"Broj igrača za {selectedCountry}: {players.Count}");
             
            pnlPlayers.Controls.Clear();

            foreach (var player in players)
            {
                var control = new PlayerControl(player, isFavourite: false);            
                pnlPlayers.Controls.Add(control);

            }
        }

        public void SelectPlayer(StartingEleven player)
        {
            selectedPlayer = player;
            lblName.Text = player.Name;
            lblShirt.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position.ToString();
            lblCaptain.Text = player.Captain ? "Da" : "Ne";
            lblFavPlayer.Text = "Nije dodan";
            pictureBox.Image = null;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (selectedPlayer == null) return;

            foreach (Control ctrl in pnlFavPlayers.Controls)
            {
                if (ctrl is Label lbl && lbl.Text == selectedPlayer.Name)
                    return;
            }

            Label favLabel = new Label
            {
                Text = selectedPlayer.Name,
                Width = pnlFavPlayers.Width - 25,
                Height = 30,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            favLabel.Click += (s, ev) =>
            {
                lblName.Text = selectedPlayer.Name;
                lblFavPlayer.Text = "Omiljeni igrač";
            };

            pnlFavPlayers.Controls.Add(favLabel);
            lblFavPlayer.Text = "Omiljeni igrač";

            SaveFavPlayers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlFavPlayers.Controls)
            {
                if (ctrl is Label lbl && lbl.Text == selectedPlayer?.Name)
                {
                    pnlFavPlayers.Controls.Remove(ctrl);
                    lblFavPlayer.Text = "Nije dodan";
                    SaveFavPlayers();
                    break;
                }
            }
        }

        private void btnPicutre_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void SaveFavPlayers()
        {
            var names = pnlFavPlayers.Controls
                .OfType<Label>()
                .Select(lbl => lbl.Text)
                .ToList();

            File.WriteAllLines(FavPlayersFile, names);
        }

        private void LoadFavPlayers()
        {
            if (!File.Exists(FavPlayersFile)) return;

            var lines = File.ReadAllLines(FavPlayersFile);

            foreach (var name in lines)
            {
                Label favLabel = new Label
                {
                    Text = name,
                    Width = pnlFavPlayers.Width - 25,
                    Height = 30,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };

                favLabel.Click += (s, ev) =>
                {
                    lblName.Text = name;
                    lblFavPlayer.Text = "Omiljeni igrač";
                };

                pnlFavPlayers.Controls.Add(favLabel);
            }
        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerControl)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        private void PlayerControl_Click(object sender, EventArgs e)
        {
            if (sender is PlayerControl pc && pc.PlayerData != null)
            {
                SelectPlayer(pc.PlayerData);
            }
        }

        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerControl)))
            {
                var playerControl = (PlayerControl)e.Data.GetData(typeof(PlayerControl));
                var targetPanel = sender as FlowLayoutPanel;

                var currentParent = playerControl.Parent as FlowLayoutPanel;
                if (currentParent != null && currentParent != targetPanel)
                {
                    currentParent.Controls.Remove(playerControl);
                    targetPanel.Controls.Add(playerControl);

                    //  Rebind Click event da radi desni prikaz
                    playerControl.Click -= PlayerControl_Click;
                    playerControl.Click += PlayerControl_Click;
                }
            }
        }

     

        public void MovePlayerControl(PlayerControl control, bool toFavourite)
        {
            if (toFavourite)
            {
                if (!pnlFavPlayers.Controls.Contains(control))
                {
                    pnlPlayers.Controls.Remove(control);
                    pnlFavPlayers.Controls.Add(control);

                    control.Click -= PlayerControl_Click;
                    control.Click += PlayerControl_Click;
                }
            }
            else
            {
                if (!pnlPlayers.Controls.Contains(control))
                {
                    pnlFavPlayers.Controls.Remove(control);
                    pnlPlayers.Controls.Add(control);

                    control.Click -= PlayerControl_Click;
                    control.Click += PlayerControl_Click;
                }
            }
        }




        private void lblPlayers_Click(object sender, EventArgs e) { }
        private void lblFavPlayers_Click(object sender, EventArgs e) { }
        private void lblPlayer_Click(object sender, EventArgs e) { }
        private void pnlPlayers_Paint(object sender, PaintEventArgs e) { }
        private void pnlFavPlayers_Paint(object sender, PaintEventArgs e) { }
        private void pnlPlayer_Paint(object sender, PaintEventArgs e) { }
        private void lblRepresentation_Click(object sender, EventArgs e) { }
        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void pictureBox_Click(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void lblShirt_Click(object sender, EventArgs e) { }
        private void lblPosition_Click(object sender, EventArgs e) { }
        private void lblCaptain_Click(object sender, EventArgs e) { }
        private void lblFavPlayer_Click(object sender, EventArgs e) { }
    }
}
