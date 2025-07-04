﻿using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Data.Models;

namespace WpfApp
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl(StartingEleven player)
        {
            InitializeComponent();

            txtName.Text = player.Name;
            txtNumber.Text = $"#{player.ShirtNumber}";

            string imgPath = $"Resources/{player.Name.Replace(" ", "_").ToLower()}.png";
            if (!System.IO.File.Exists(imgPath))
                imgPath = "Resources/funcuti.jpeg";

            imgShirt.Source = new BitmapImage(new Uri(imgPath, UriKind.Relative));

        }
    }
}
