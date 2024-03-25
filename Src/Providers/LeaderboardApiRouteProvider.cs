using System;
using System.Collections.Generic;
using TheFinals.NET.Enums;
using TheFinals.NET.Models;

namespace TheFinals.NET.Providers
{
    public interface IApiRouteProvider
    {
        LeaderboardApiRoute GetApiRoute(LeaderboardVersion leaderboardVersion);
    }

    public class LeaderboardApiRouteProvider : IApiRouteProvider
    {
        private readonly Dictionary<LeaderboardVersion, LeaderboardApiRoute> _apiRoutes;

        public LeaderboardApiRouteProvider(Dictionary<LeaderboardVersion, LeaderboardApiRoute> apiRoutes)
        {
            _apiRoutes = apiRoutes ?? throw new ArgumentNullException(nameof(apiRoutes));
        }

        public LeaderboardApiRoute GetApiRoute(LeaderboardVersion leaderboardVersion)
        {
            if (_apiRoutes.TryGetValue(leaderboardVersion, out var apiRoute))
            {
                return apiRoute;
            }

            throw new KeyNotFoundException($"No API route found for leaderboard version {leaderboardVersion}");
        }
    }
}