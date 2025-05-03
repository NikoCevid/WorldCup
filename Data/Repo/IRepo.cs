using Data.Models;

public interface IRepo
{
    Task<List<Team>> GetAllTeamsAsync();
    Task<List<MatchDetail>> GetAllMatchDetailsAsync();
    Task<List<TeamEvent>> GetAllTeamEventsAsync();
    Task<List<StartingEleven>> GetStartingElevensAsync();
    Task<List<TeamStatistics>> GetTeamStatisticsAsync();
    Task<List<Weather>> GetWeatherInfoAsync();
    Task LoadDataAsync(string championshipUrl); 
}
