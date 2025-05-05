using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class StartupForm : Form
    {
        private const string SettingsFilePath = "settings.txt";
        private const string ConfigFilePath = "config/config.txt";

        public string SelectedChampionship => cmbChampionship.SelectedItem?.ToString();
        public string SelectedLanguage => cmbLanguage.SelectedItem?.ToString();

        public StartupForm(Data.DataService dataService)
        {
            InitializeComponent();

            if (File.Exists(SettingsFilePath))
            {
                string[] lines = File.ReadAllLines(SettingsFilePath);
                if (lines.Length == 2)
                {
                    ApplyCulture(lines[1]);
                    // Ako ne želiš da aplikacija odmah ide dalje, izbriši Close() i omogući ponovno biranje.
                    // Close();
                }
            }

            LoadSettingsOptions();
        }

        private void LoadSettingsOptions()
        {
            cmbChampionship.Items.AddRange(new string[] { "Men", "Women" });
            cmbChampionship.SelectedIndex = 0;

            cmbLanguage.Items.AddRange(new string[] { "en", "hr" });
            cmbLanguage.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cmbChampionship.SelectedItem == null || cmbLanguage.SelectedItem == null)
            {
                MessageBox.Show("Please select both championship and language.");
                return;
            }

            string championship = cmbChampionship.SelectedItem.ToString().ToLower();
            string language = cmbLanguage.SelectedItem.ToString().ToLower();
            string mode = "api"; // fiksno

            // Spremanje postavki u settings.txt
            File.WriteAllLines(SettingsFilePath, new string[] { championship, language });

            //// Spremanje u config/config.txt za RepoFactory
            Directory.CreateDirectory(Path.GetDirectoryName(ConfigFilePath));
            File.WriteAllLines(ConfigFilePath, new string[] { mode, championship, language });

            ApplyCulture(language);

            MessageBox.Show("Settings saved. Load your main form here.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Kada imaš glavnu formu, koristi ovo:
            // Hide();
            // var mainForm = new MainCountryForm(); // ili kako se zove tvoja glavna forma
            // mainForm.Show();

            Close();
        }

        private void ApplyCulture(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(langCode);
        }

        private void lbChampionship_Click(object sender, EventArgs e) { }
        private void cmbChampionship_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lbLanguage_Click(object sender, EventArgs e) { }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
