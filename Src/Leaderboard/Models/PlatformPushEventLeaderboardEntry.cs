using Newtonsoft.Json;

namespace TheFinals.NET.Leaderboard.Models
{
    public class PlatformPushEventLeaderboardEntry : BaseLeaderboardEntry
    {
        [JsonProperty("d")]
        public double Distance { get; set; }
    }
}