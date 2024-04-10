using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheFinals.NET.Leaderboard.Models;

namespace TheFinals.NET.Leaderboard.Endpoints
{
    public class PlatformPushEventLeaderboardService : IEventLeaderboardService<PlatformPushEventLeaderboard>
    {
        private readonly HttpClient _httpClient;

        public PlatformPushEventLeaderboardService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<PlatformPushEventLeaderboard> GetAsync(int? count = null, string nameFilter = null)
        {
            string url = $"https://storage.googleapis.com/embark-discovery-leaderboard/platform-push-event-leaderboard-discovery-live.json";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                PlatformPushEventLeaderboard eventLeaderboard = JsonConvert.DeserializeObject<PlatformPushEventLeaderboard>(responseContent);

                // If a name filter is provided, filter the entries by name
                if (!string.IsNullOrEmpty(nameFilter))
                {
                    eventLeaderboard.Entries = eventLeaderboard.Entries.Where(entry => entry.Name.ToLower().Contains(nameFilter.ToLower())).ToList();
                }

                // If count is provided, return only the first 'count' entries
                if (count != null)
                {
                    eventLeaderboard.Entries = eventLeaderboard.Entries.Take(count.Value).ToList();
                }

                return eventLeaderboard;
            }

            return null;
        }
    }
}