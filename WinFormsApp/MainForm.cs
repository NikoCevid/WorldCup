using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private AppConfig config;

        public MainForm()
        {
            InitializeComponent();
        }

        private List<MatchDetail> matchList;

        private void MainForm_Load(object sender, EventArgs e)
        {
            string path = "putanja/do/tvoje/datoteke.json"; // Promijeni u stvarnu putanju
            string json = File.ReadAllText(path);
            matchList = JsonConvert.DeserializeObject<List<MatchDetail>>(json);

            var representations = matchList
                .Select(m => m.HomeTeamCountry)
                .Distinct()
                .ToList();

            cmbRepresentation.DataSource = representations;
        }
        private void lblPlayers_Click(object sender, EventArgs e)
        {

        }

        private void lblFavPlayers_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayer_Click(object sender, EventArgs e)
        {

        }

        private void pnlPlayers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFavPlayers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPlayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (selectedPlayer == null) return;

            foreach (Control ctrl in pnlFavPlayers.Controls)
            {
                if (ctrl is Label lbl && lbl.Text == selectedPlayer.Name)
                    return; // Već postoji
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
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlFavPlayers.Controls)
            {
                if (ctrl is Label lbl && lbl.Text == selectedPlayer?.Name)
                {
                    pnlFavPlayers.Controls.Remove(ctrl);
                    lblFavPlayer.Text = "Nije dodan";
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

        private void cmbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTeam = cmbRepresentation.SelectedItem.ToString();

            var match = matchList
                .FirstOrDefault(m => m.HomeTeamCountry == selectedTeam || m.AwayTeamCountry == selectedTeam);

            var players = match?.HomeTeamCountry == selectedTeam
                ? match.HomeTeamStatistics.StartingEleven
                : match.AwayTeamStatistics.StartingEleven;

            pnlPlayers.Controls.Clear();

            foreach (var player in players)
            {
                Button playerBtn = new Button
                {
                    Text = player.Name,
                    Tag = player,
                    Width = pnlPlayers.Width - 25,
                    Height = 40,
                    Margin = new Padding(5)
                };
                playerBtn.Click += PlayerBtn_Click;
                pnlPlayers.Controls.Add(playerBtn);
            }
        }

        private void PlayerBtn_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            selectedPlayer = btn.Tag as StartingEleven;

            lblName.Text = selectedPlayer.Name;
            lblShirt.Text = selectedPlayer.ShirtNumber.ToString();
            lblPosition.Text = selectedPlayer.Position.ToString();
            lblCaptain.Text = selectedPlayer.Captain ? "Da" : "Ne";
            lblFavPlayer.Text = "Nije dodan";
            pictureBox.Image = null;
        }

        private StartingEleven selectedPlayer;

       

       

        private void lblRepresentation_Click(object sender, EventArgs e)
        {

        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblShirt_Click(object sender, EventArgs e)
        {

        }

        private void lblPosition_Click(object sender, EventArgs e)
        {

        }

        private void lblCaptain_Click(object sender, EventArgs e)
        {

        }

        private void lblFavPlayer_Click(object sender, EventArgs e)
        {

        }
    }
}
