using Data.Models;
using Newtonsoft.Json;

public class FileRepo : IRepo
{
    private List<MatchDetail> _matchDetails;
    private List<Team> _teams;

    public FileRepo(string matchesPath, string teamsPath)
    {
        _matchDetails = LoadFromFile<MatchDetail>(matchesPath);
        _teams = LoadFromFile<Team>(teamsPath);
    }

    public Task<List<Team>> GetAllTeamsAsync() => Task.FromResult(_teams);
    public Task<List<MatchDetail>> GetAllMatchDetailsAsync() => Task.FromResult(_matchDetails);
    public Task<List<TeamEvent>> GetAllTeamEventsAsync() => Task.FromResult(
        _matchDetails
            .SelectMany(m => (m.HomeTeamEvents ?? new List<TeamEvent>())
            .Concat(m.AwayTeamEvents ?? new List<TeamEvent>()))
            .ToList()
    );
    public Task<List<TeamStatistics>> GetTeamStatisticsAsync() => Task.FromResult(
        _matchDetails
            .SelectMany(m => new[] { m.HomeTeamStatistics, m.AwayTeamStatistics })
            .Where(stat => stat != null)
            .Cast<TeamStatistics>()
            .ToList()
    );
    public Task<List<StartingEleven>> GetStartingElevensAsync() => Task.FromResult(
        _matchDetails
            .SelectMany(m => new[] { m.HomeTeamStatistics, m.AwayTeamStatistics })
            .Where(stat => stat != null)
            .SelectMany(stat => stat.StartingEleven.Concat(stat.Substitutes))
            .ToList()
    );
    public Task<List<Weather>> GetWeatherInfoAsync() => Task.FromResult(
        _matchDetails
            .Where(m => m.Weather != null)
            .Select(m => m.Weather!)
            .ToList()
    );

    public Task LoadDataAsync(string championshipUrl) => Task.CompletedTask;

    private List<T> LoadFromFile<T>(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Greška pri čitanju datoteke: {path}\n{ex.Message}");
        }

        return new List<T>();
    }
}
