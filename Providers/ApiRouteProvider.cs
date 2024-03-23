using TheFinals.NET.Enums;
using TheFinals.NET.Models;

namespace TheFinals.NET.Providers
{
    public interface IApiRouteProvider
    {
        ApiRoute GetApiRoute(LeaderboardVersion leaderboardVersion);
    }

    public class ApiRouteProvider : IApiRouteProvider
    {
        private readonly Dictionary<LeaderboardVersion, ApiRoute> _apiRoutes;

        public ApiRouteProvider(Dictionary<LeaderboardVersion, ApiRoute> apiRoutes)
        {
            _apiRoutes = apiRoutes ?? throw new ArgumentNullException(nameof(apiRoutes));
        }

        public ApiRoute GetApiRoute(LeaderboardVersion leaderboardVersion)
        {
            if (_apiRoutes.TryGetValue(leaderboardVersion, out var apiRoute))
            {
                return apiRoute;
            }

            throw new KeyNotFoundException($"No API route found for leaderboard version {leaderboardVersion}");
        }
    }
}