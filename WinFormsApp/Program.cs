using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;
using Data; // pretpostavka: DataService je u ovom namespace-u

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Uèitaj konfiguraciju iz appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            string dataSource = configuration["DataSource"] ?? "API";

            // Inicijaliziraj podatkovni sloj
            var dataService = new DataService(dataSource);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(dataService)); // pretpostavka: Form1 ima konstruktor koji prima DataService
        }
    }
}
