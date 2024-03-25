using System;
using System.Collections.Generic;
using TheFinals.NET.Enums;

namespace TheFinals.NET.Models
{
    public class LeaderboardApiRoute
    {
        public List<LeaderboardVersion> Versions { get; set; }
        public List<Platform> AvailablePlatforms { get; set; }
        public Func<Platform, string> Url { get; set; }
    }
}