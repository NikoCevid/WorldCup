using System;
using System.IO;
using System.Windows.Forms;
using Data;

namespace WinFormsApp
{
    internal static class Program
    {
        [STAThread]


        static void Main()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "config.txt");

                if (!File.Exists(configPath))
                    throw new FileNotFoundException("Nedostaje konfiguracijska datoteka: " + configPath);

                string[] lines = File.ReadAllLines(configPath);
                if (lines.Length < 1)
                    throw new InvalidOperationException("Konfiguracijska datoteka mora imati barem jednu liniju (sourceType).");

                string sourceType = lines[0].Trim(); // "api" ili "file"

                var dataService = new DataService(sourceType); 

                ApplicationConfiguration.Initialize();
                Application.Run(new StartupForm(dataService));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri pokretanju aplikacije:\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

     

    }
}
