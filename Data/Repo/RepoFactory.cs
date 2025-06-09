using System;
using System.IO;

namespace Data
{
    public static class RepoFactory
    {
        private const string CONFIG_PATH = "config/config.txt"; // relativna putanja

        public static string Language { get; private set; } = "en"; // dostupno izvana ako treba

        // Postojeća metoda koja čita iz config.txt
        public static IRepo CreateRepo()
        {
            // Ako config ne postoji, kreiraj ga sa default vrijednostima
            if (!File.Exists(CONFIG_PATH))
            {
                File.WriteAllLines(CONFIG_PATH, new string[] { "api", "men", "en" }); // default: API, muško prvenstvo, engleski jezik
                Directory.CreateDirectory(Path.GetDirectoryName(CONFIG_PATH));
            }

            string[] lines = File.ReadAllLines(CONFIG_PATH);
            if (lines.Length < 2)
                throw new InvalidOperationException("Datoteka mora imati barem 2 linije: način i prvenstvo.");

            string mode = lines[0].Trim().ToLower();       // api ili file
            string championship = lines[1].Trim().ToLower(); // men ili women
            Language = lines.Length > 2 ? lines[2].Trim().ToLower() : "en"; // en ili hr

            return CreateRepo(mode, championship);
        }

        // Nova metoda koja prima sourceType, defaulta championship na "men"
        public static IRepo CreateRepo(string sourceType)
        {
            string mode = sourceType.Trim().ToLower();
            string championship = "men"; // default

            return CreateRepo(mode, championship);
        }

        // Interna metoda koja prihvaća oba parametra
        public static IRepo CreateRepo(string mode, string championship)
        {
            switch (mode)
            {
                case "api":
                    return new APIRepo(championship == "women");

                case "file":
                    string matchesFile = championship == "women" ? "data/json/women_matches.json" : "data/json/men_matches.json";
                    string teamsFile = championship == "women" ? "data/json/women_teams.json" : "data/json/men_teams.json";
                    return new FileRepo(matchesFile, teamsFile);

                default:
                    throw new InvalidOperationException("Nepoznat nacin učitavanja. Dozvoljeno: api ili file.");
            }
        }
    }
}
