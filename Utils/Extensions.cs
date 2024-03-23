using TheFinals.NET.Enums;

namespace TheFinals.NET.Utils
{
    public static class Extensions
    {
        public static string ToApiString(this LeaderboardVersion version)
        {
            return version switch
            {
                LeaderboardVersion.ClosedBeta1 => "cb1",
                LeaderboardVersion.ClosedBeta2 => "cb2",
                LeaderboardVersion.OpenBeta => "ob",
                LeaderboardVersion.Season1 => "s1",
                LeaderboardVersion.Season2 => "s2",
                LeaderboardVersion.Live => "live",
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(version)),
            };
        }
    }
}