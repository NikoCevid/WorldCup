﻿using Data.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class APIRepo : IRepo
{
    private readonly string _baseUrl;

    public APIRepo(bool isWomen)
    {
        _baseUrl = isWomen
            ? "https://worldcup-vua.nullbit.hr/women/"
            : "https://worldcup-vua.nullbit.hr/men/";
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        var client = new RestClient(_baseUrl + "teams/results");
        var response = await client.ExecuteAsync(new RestRequest());
        return response.IsSuccessful
            ? JsonConvert.DeserializeObject<List<Team>>(response.Content) ?? new List<Team>()
            : new List<Team>();
    }

    public async Task<List<MatchDetail>> GetAllMatchDetailsAsync()
    {
        var client = new RestClient(_baseUrl + "matches");
        var response = await client.ExecuteAsync(new RestRequest());
        return response.IsSuccessful
            ? JsonConvert.DeserializeObject<List<MatchDetail>>(response.Content) ?? new List<MatchDetail>()
            : new List<MatchDetail>();
    }

    public async Task<List<MatchDetail>> GetMatchDetailsAsync(string fifaCode)
    {
        var allMatches = await GetAllMatchDetailsAsync();

        return allMatches
            .Where(m =>
                string.Equals(m.HomeTeam?.FifaCode?.Trim(), fifaCode.Trim(), StringComparison.OrdinalIgnoreCase) ||
                string.Equals(m.AwayTeam?.FifaCode?.Trim(), fifaCode.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public Task<List<TeamEvent>> GetAllTeamEventsAsync() => Task.FromResult(new List<TeamEvent>());

    public Task<List<StartingEleven>> GetStartingElevensAsync() => Task.FromResult(new List<StartingEleven>());

    public Task<List<TeamStatistics>> GetTeamStatisticsAsync() => Task.FromResult(new List<TeamStatistics>());

    public Task<List<Weather>> GetWeatherInfoAsync() => Task.FromResult(new List<Weather>());

    public Task LoadDataAsync(string championshipUrl) => Task.CompletedTask;
}
