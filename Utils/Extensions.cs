using System;
using TheFinals.NET.Enums;

namespace TheFinals.NET.Utils
{
    public static class Extensions
    {
        public static string ToApiString(this LeaderboardVersion version)
        {
            switch (version)
            {
                case LeaderboardVersion.ClosedBeta1:
                    return "cb1";
                case LeaderboardVersion.ClosedBeta2:
                    return "cb2";
                case LeaderboardVersion.OpenBeta:
                    return "ob";
                case LeaderboardVersion.Season1:
                    return "s1";
                case LeaderboardVersion.Season2:
                    return "s2";
                case LeaderboardVersion.Live:
                    return "live";
                default:
                    throw new ArgumentException(message: "invalid enum value", paramName: nameof(version));
            }
        }
    }
}