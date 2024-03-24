using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheFinals.NET.Models
{
    public class LeaderboardEntry
    {
        [JsonProperty("r")]
        public int Rank { get; set; }

        [JsonProperty("ri")]
        public int? LeagueNumber { get; set; }

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

        public string League => LeagueNumber.HasValue ? NumberToLeague(LeagueNumber.Value) : null;

        private static string NumberToLeague(int leagueNumber)
        {
            var leagueMap = new Dictionary<int, string>
            {
                { 0, "Unranked" },
                { 1, "Bronze 4" },
                { 2, "Bronze 3" },
                { 3, "Bronze 2" },
                { 4, "Bronze 1" },
                { 5, "Silver 4" },
                { 6, "Silver 3" },
                { 7, "Silver 2" },
                { 8, "Silver 1" },
                { 9, "Gold 4" },
                { 10, "Gold 3" },
                { 11, "Gold 2" },
                { 12, "Gold 1" },
                { 13, "Platinum 4" },
                { 14, "Platinum 3" },
                { 15, "Platinum 2" },
                { 16, "Platinum 1" },
                { 17, "Diamond 4" },
                { 18, "Diamond 3" },
                { 19, "Diamond 2" },
                { 20, "Diamond 1" }
            };

            return leagueMap.TryGetValue(leagueNumber, out var league) ? league : null;
        }
    }
}