using Newtonsoft.Json;

namespace TheFinals.NET.Leaderboard.Models
{
    public class BaseLeaderboardEntry
    {
        [JsonProperty("r")]
        public int Rank { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steam")]
        public string SteamName { get; set; }

        [JsonProperty("xbox")]
        public string XboxName { get; set; }

        [JsonProperty("psn")]
        public string PsnName { get; set; }
    }
}