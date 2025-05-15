using Data.Models;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using WinFormsApp.Helpers;
using System.Windows.Forms;

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
        }

        private void SetupControl()
        {
            lblName.Text = PlayerData.Name;
            lblNumber.Text = $"#{PlayerData.ShirtNumber}";
            lblPosition.Text = PlayerData.Position.ToString();
            lblCaptain.Text = PlayerData.Captain ? "Kapetan" : "";
            picStar.Visible = IsFavourite;

            string imgPath = Path.Combine("player_pictures", $"{PlayerData.Name}.png");
            picStar.Image = ImageHelper.LoadEmbeddedImage("WinFormsApp.Resources.star.png");
            picPlayer.Image = ImageHelper.LoadEmbeddedImage("WinFormsApp.Resources.default_player.png");


        }

        private Image LoadEmbeddedImage(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(resourceName);
            return stream != null ? Image.FromStream(stream) : null;
        }

    }
}
