using System.IO;

namespace WinFormsApp
{
    public class AppConfig
    {
        public string Source { get; set; } = "api"; // "api" ili "json"
        public string Gender { get; set; } = "men"; // "men" ili "women"

        public static AppConfig Load(string path)
        {
            var lines = File.ReadAllLines(path);
            var config = new AppConfig();

            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length != 2) continue;
                var key = parts[0].Trim().ToLower();
                var value = parts[1].Trim().ToLower();

                if (key == "source") config.Source = value;
                else if (key == "gender") config.Gender = value;
            }

            return config;
        }
    }
}
