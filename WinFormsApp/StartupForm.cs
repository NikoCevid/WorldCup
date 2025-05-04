using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Data;

namespace WinFormsApp
{
    public partial class StartupForm : Form
    {
        private const string SettingsFile = "config.txt";
        private readonly DataService _dataService;

        public StartupForm(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            LoadPreviousSettings();
        }

        private void LoadPreviousSettings()
        {
            if (File.Exists(SettingsFile))
            {
                var lines = File.ReadAllLines(SettingsFile);
                if (lines.Length >= 2)
                {
                    cmbTournament.SelectedItem = lines[0];
                    cmbLanguage.SelectedItem = lines[1];
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbTournament.SelectedItem == null || cmbLanguage.SelectedItem == null)
            {
                MessageBox.Show("Odaberite prvenstvo i jezik.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTournament = cmbTournament.SelectedItem.ToString();
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();

            File.WriteAllLines(SettingsFile, new[] { selectedTournament, selectedLanguage });

            Thread.CurrentThread.CurrentUICulture = selectedLanguage == "Hrvatski"
                ? new CultureInfo("hr")
                : new CultureInfo("en");

            this.Hide();
            var mainForm = new StartupForm(_dataService); // ✅ otvaramo stvarnu glavnu formu
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
        }
    }
}
