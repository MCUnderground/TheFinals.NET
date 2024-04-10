using System.Net.Http;
using TheFinals.NET.Leaderboard.Models;

namespace TheFinals.NET.Leaderboard.Endpoints
{
    public class LeaderboardServices
    {
        public ILeaderboardService Main { get; }
        public IEventLeaderboardService<PlatformPushEventLeaderboard> PlatformPushEvent { get; }

        public LeaderboardServices(HttpClient httpClient)
        {
            // Initialize services
            Main = new LeaderboardService(httpClient);
            PlatformPushEvent = new PlatformPushEventLeaderboardService(httpClient);
        }
    }
}