using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();

            // Jezik
            cmbLanguage.ItemsSource = new List<string> { "hr", "en" };
            cmbLanguage.SelectedIndex = 0;

            // Prvenstvo
            cmbChampionship.ItemsSource = new List<string> { "men", "women" };
            cmbChampionship.SelectedIndex = 0;

            // Rezolucija
            cmbResolution.ItemsSource = new List<string> { "1280x720", "1920x1080", "fullscreen" };
            cmbResolution.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            var lang = cmbLanguage.SelectedItem?.ToString() ?? "hr";
            var champ = cmbChampionship.SelectedItem?.ToString() ?? "men";
            var resolution = cmbResolution.SelectedItem?.ToString() ?? "1280x720";

            Directory.CreateDirectory("config");
            File.WriteAllLines("config/wpf_settings.txt", new[]
            {
        $"Language={lang}",
        $"Championship={champ}",
        $"Resolution={resolution}"
    });

            var mainWindow = new MainWindow();

            if (resolution == "fullscreen")
            {
                mainWindow.WindowState = WindowState.Maximized;
            }
            else if (resolution.Contains("x"))
            {
                var parts = resolution.Split('x');
                if (int.TryParse(parts[0], out int width) && int.TryParse(parts[1], out int height))
                {
                    mainWindow.Width = width;
                    mainWindow.Height = height;
                }
            }

            mainWindow.Show();
            this.Close(); // zatvori StartupWindow
        }





    }
}