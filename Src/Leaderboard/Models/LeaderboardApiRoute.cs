using System;
using System.Collections.Generic;
using TheFinals.NET.Leaderboard.Enums;

namespace TheFinals.NET.Leaderboard.Models
{
    public class LeaderboardApiRoute
    {
        public List<Platform> AvailablePlatforms { get; set; }
        public Func<Platform, string> Url { get; set; }
    }
}