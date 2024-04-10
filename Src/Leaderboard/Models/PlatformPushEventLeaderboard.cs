using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheFinals.NET.Leaderboard.Models
{
    public class PlatformPushEventLeaderboard
    {
        [JsonProperty("goal")]
        public double Goal { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("entries")]
        public List<PlatformPushEventLeaderboardEntry> Entries { get; set; }
    }
}