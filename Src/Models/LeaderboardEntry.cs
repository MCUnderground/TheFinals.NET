using Newtonsoft.Json;
using System.Collections.Generic;
using TheFinals.NET.Enums;

namespace TheFinals.NET.Models
{
    public class LeaderboardEntry
    {
        [JsonProperty("r")]
        public int Rank { get; set; }

        [JsonProperty("ri")]
        public League League { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

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

        [JsonProperty("steam")]
        public string SteamName { get; set; }

        [JsonProperty("xbox")]
        public string XboxName { get; set; }

        [JsonProperty("psn")]
        public string PsnName { get; set; }

        // Calculated properties
        public int ChangeInRank => OriginalRank - Rank;
    }
}