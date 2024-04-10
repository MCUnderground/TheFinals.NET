using Newtonsoft.Json;
using TheFinals.NET.Leagues.Enums;

namespace TheFinals.NET.Leaderboard.Models
{
    public class LeaderboardEntry : BaseLeaderboardEntry
    {
        [JsonProperty("ri")]
        public League League { get; set; }

        [JsonProperty("f")]
        public int Fame { get; set; }

        [JsonProperty("of")]
        public int OriginalFame { get; set; }

        [JsonProperty("or")]
        public int OriginalRank { get; set; }

        [JsonProperty("x")]
        public int? Xp { get; set; }

        [JsonProperty("mx")]
        public int? MaxLevel { get; set; }

        [JsonProperty("c")]
        public int Cashouts { get; set; }

        // Calculated properties
        public int ChangeInRank => OriginalRank - Rank;
    }
}