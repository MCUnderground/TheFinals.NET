using System.Net.Http;
using TheFinals.NET.Image.Endpoints;
using TheFinals.NET.Leaderboard.Endpoints;
using TheFinals.NET.Leagues.Endpoints;

namespace TheFinals.NET
{
    public class TheFinalsClient
    {
        private readonly HttpClient _httpClient;
        public LeaderboardServices Leaderboards { get; }
        public ILeagueService League { get; }
        public IImageService Image { get; }

        public TheFinalsClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            // Initialize services
            Leaderboards = new LeaderboardServices(_httpClient);
            League = new LeagueService(_httpClient);
            Image = new ImageService(_httpClient);
        }
    }
}