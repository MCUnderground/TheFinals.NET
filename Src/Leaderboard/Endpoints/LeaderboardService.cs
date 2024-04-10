using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheFinals.NET.Leaderboard.Enums;
using TheFinals.NET.Leaderboard.Models;
using TheFinals.NET.Leaderboard.Providers;

namespace TheFinals.NET.Leaderboard.Endpoints
{
    public interface ILeaderboardService
    {
        Task<List<LeaderboardEntry>> GetAsync(LeaderboardVersion leaderboardVersion, Platform platform = Platform.Crossplay, int? count = null, string nameFilter = null);
    }

    public class LeaderboardService : ILeaderboardService
    {
        private readonly IApiRouteProvider _apiRouteProvider;
        private readonly HttpClient _httpClient;

        private Dictionary<LeaderboardVersion, LeaderboardApiRoute> InitializeApiRoutes()
        {
            return new Dictionary<LeaderboardVersion, LeaderboardApiRoute>
            {
                {
                    LeaderboardVersion.ClosedBeta1,
                    new LeaderboardApiRoute {
                        AvailablePlatforms = new List<Platform>(),
                        Url = platform => "https://embark-discovery-leaderboard.storage.googleapis.com/leaderboard-beta-1.json"
                    }
                },

                {
                    LeaderboardVersion.ClosedBeta2,
                    new LeaderboardApiRoute {
                        AvailablePlatforms = new List<Platform>(),
                        Url = platform => "https://embark-discovery-leaderboard.storage.googleapis.com/leaderboard.json" }
                },
                {
                    LeaderboardVersion.OpenBeta,
                    new LeaderboardApiRoute {
                        AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn },
                        Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/leaderboard-{platform}.json" }
                },
                {
                    LeaderboardVersion.Season1,
                    new LeaderboardApiRoute {
                        AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn },
                        Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/leaderboard-{platform}-discovery-live.json" }
                },
                {
                    LeaderboardVersion.Season2,
                    new LeaderboardApiRoute {
                        AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn },
                        Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/s2-leaderboard-{platform}-discovery-live.json" }
                },
                {
                    LeaderboardVersion.Live,
                    new LeaderboardApiRoute {
                        AvailablePlatforms = new List<Platform> { Platform.Crossplay, Platform.Steam, Platform.Xbox, Platform.Psn },
                        Url = platform => $"https://storage.googleapis.com/embark-discovery-leaderboard/s2-leaderboard-{platform}-discovery-live.json" }
                },
            };
        }

        public LeaderboardService(HttpClient httpClient)
        {
            _apiRouteProvider = new LeaderboardApiRouteProvider(InitializeApiRoutes());
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Asynchronously retrieves leaderboard data from a specified API endpoint.
        /// </summary>
        /// <param name="leaderboardVersion">The version of the leaderboard to retrieve. This parameter is required.</param>
        /// <param name="platform">The platform for which to retrieve the leaderboard. If not provided, defaults to Platform.Crossplay. Not needed for ClosedBeta</param>
        /// <param name="count">The maximum number of leaderboard entries to retrieve. If not provided, all available entries are retrieved.</param>
        /// <param name="nameFilter">A name to filter the leaderboard entries by. If provided, only entries with a name that contains this string are returned.</param>
        /// <returns>A list of LeaderboardEntry objects, or null if an error occurs.</returns>
        public async Task<List<LeaderboardEntry>> GetAsync(LeaderboardVersion leaderboardVersion, Platform platform = Platform.Crossplay, int? count = null, string nameFilter = null)
        {
            var apiRoute = _apiRouteProvider.GetApiRoute(leaderboardVersion);

            string url = apiRoute?.Url(platform).ToLower() ?? null;

            if (url == null)
                return null;

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                List<LeaderboardEntry> leaderboardEntries = JsonConvert.DeserializeObject<List<LeaderboardEntry>>(responseContent);

                // If a name filter is provided, filter the entries by name
                if (!string.IsNullOrEmpty(nameFilter))
                {
                    leaderboardEntries = leaderboardEntries?.Where(entry => entry.Name.ToLower().Contains(nameFilter.ToLower())).ToList();
                }

                // If count is provided, return only the first 'count' entries
                if (count != null)
                {
                    leaderboardEntries = leaderboardEntries?.Take(count.Value).ToList();
                }

                return leaderboardEntries;
            }

            return null;
        }
    }
}