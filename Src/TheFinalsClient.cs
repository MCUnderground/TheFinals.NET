using System.Collections.Generic;
using System.Net.Http;
using TheFinals.NET.Endpoints;
using TheFinals.NET.Enums;
using TheFinals.NET.Models;
using TheFinals.NET.Providers;

namespace TheFinals.NET
{
    public class TheFinalsClient
    {
        private readonly HttpClient _httpClient;
        public ILeaderboardService Leaderboard { get; }
        public ILeagueService League { get; }

        public TheFinalsClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            // Initialize services
            Leaderboard = new LeaderboardService(_httpClient);
            League = new LeagueService(_httpClient);
        }
    }
}