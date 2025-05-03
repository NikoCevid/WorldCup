using Data.Models;
using Data;

public class DataService
{
    private readonly IRepo repo;

    public DataService()
    {
        try
        {
            repo = RepoFactory.CreateRepo();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Greška pri učitavanju izvora podataka: " + ex.Message);
            throw;
        }
    }

    public async Task<(List<Team> teams, List<MatchDetail> matchDetails)> GetMatchDataAsync()
    {
        try
        {
            var teams = await repo.GetAllTeamsAsync();
            var matchDetails = await repo.GetAllMatchDetailsAsync();
            return (teams, matchDetails);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Greška pri dohvaćanju podataka: " + ex.Message);
            return (new List<Team>(), new List<MatchDetail>());
        }
    }
}
