using Data.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormsApp.Helpers;

namespace WinFormsApp
{
    public partial class PlayerControl : UserControl
    {
        public StartingEleven PlayerData { get; private set; }
        public bool IsFavourite { get; private set; }

        public PlayerControl(StartingEleven player, bool isFavourite = false)
        {
            InitializeComponent();
            PlayerData = player;
            IsFavourite = isFavourite;
            SetupControl();

            // 📋 Dodavanje context menija
            this.ContextMenuStrip = new ContextMenuStrip();

            var addToFav = new ToolStripMenuItem("Dodaj u omiljene");
            addToFav.Click += (s, e) => MoveToFavourite();
            this.ContextMenuStrip.Items.Add(addToFav);

            var removeFromFav = new ToolStripMenuItem("Makni iz omiljenih");
            removeFromFav.Click += (s, e) => MoveToNonFavourite();
            this.ContextMenuStrip.Items.Add(removeFromFav);

            // ✅ Klik podrška na sve kontrole unutar PlayerControl
            this.MouseClick += PlayerControl_MouseClick;
            foreach (Control c in this.Controls)
            {
                c.MouseClick += PlayerControl_MouseClick;
            }
        }

        private void SetupControl()
        {
            lblName.Text = PlayerData.Name;
            lblNumber.Text = $"#{PlayerData.ShirtNumber}";
            lblPosition.Text = PlayerData.Position.ToString();
            lblCaptain.Text = PlayerData.Captain ? "Kapetan" : "";
            picStar.Visible = IsFavourite;

            picStar.Image = ImageHelper.LoadEmbeddedImage("WinFormsApp.Resources.star.png");

            //  Uvijek koristi default-player.png
            picPlayer.Image = ImageHelper.LoadEmbeddedImage("WinFormsApp.Resources.default-player.png");
        }



        //  Drag + selekcija
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (this.FindForm() is MainForm mainForm)
                {
                    mainForm.SelectPlayer(PlayerData);
                }
                DoDragDrop(this, DragDropEffects.Move);
            }
        }

        // ✅ Klik selektira igrača (iz bilo kojeg unutarnjeg labela)
        private void PlayerControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.FindForm() is MainForm mainForm)
            {
                mainForm.SelectPlayer(PlayerData);
            }
        }

        private void MoveToFavourite()
        {
            var parentForm = this.FindForm() as MainForm;
            parentForm?.MovePlayerControl(this, true);
        }

        private void MoveToNonFavourite()
        {
            var parentForm = this.FindForm() as MainForm;
            parentForm?.MovePlayerControl(this, false);
        }
    }
}
