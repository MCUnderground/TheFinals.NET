using TheFinals.NET.Endpoints;
using TheFinals.NET.Enums;
using TheFinals.NET.Models;
using TheFinals.NET.Providers;

namespace TheFinals.NET
{
    public class TheFinalsClient
    {
        private readonly HttpClient _httpClient;
        private Dictionary<LeaderboardVersion, ApiRoute> ApiRoutes { get; }
        public ILeaderboardService Leaderboard { get; }

        public TheFinalsClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            // Initialize API routes
            ApiRoutes = InitializeApiRoutes();

            // Initialize services
            var routeProvider = new ApiRouteProvider(ApiRoutes);
            Leaderboard = new LeaderboardService(routeProvider, _httpClient);
        }

        private Dictionary<LeaderboardVersion, ApiRoute> InitializeApiRoutes()
        {
            return new Dictionary<LeaderboardVersion, ApiRoute>
            {
                { LeaderboardVersion.ClosedBeta1, new ApiRoute { Versions =  new List<LeaderboardVersion> { LeaderboardVersion.ClosedBeta1 }, AvailablePlatforms = new List<Platform>(), Url = platform => "https://embark-discovery-leaderboard.storage.googleapis.com/leaderboard-beta-1.json" } },
                { LeaderboardVersion.ClosedBeta2, new ApiRoute { Versions =  new List<LeaderboardVersion> { LeaderboardVersion.ClosedBeta2 }, AvailablePlatforms = new List<Platform>(), Url = platform => "https://embark-discovery-leaderboard.storage.googleapis.com/leaderboard.json" } },
                { LeaderboardVersion.OpenBeta, new ApiRoute { Versions =  new List<LeaderboardVersion> { LeaderboardVersion.OpenBeta }, AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn }, Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/leaderboard-{platform}.json" } },
                { LeaderboardVersion.Season1, new ApiRoute { Versions =  new List<LeaderboardVersion> { LeaderboardVersion.Season1 }, AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn }, Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/leaderboard-{platform}-discovery-live.json" } },
                { LeaderboardVersion.Season2, new ApiRoute { Versions =  new List<LeaderboardVersion> { LeaderboardVersion.Season2 }, AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn }, Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/s2-leaderboard-{platform}-discovery-live.json" } },
            };
        }
    }
}