using TheFinals.NET;
using TheFinals.NET.Enums;
using TheFinals.NET.Enums.Image;
using TheFinals.NET.Leaderboard.Enums;
using TheFinals.NET.Leagues.Enums;

namespace Example
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task GetResult()
        {
            var client = new TheFinalsClient();
            var leaderboardSeason = await client.Leaderboards.Main.GetAsync(LeaderboardVersion.Season2);
            var leaderboardPlatformPush = await client.Leaderboards.PlatformPushEvent.GetAsync();

            if (leaderboardSeason == null)
            {
                Console.WriteLine("No leaderboard data was found.");
                return;
            }

            using (var writer = new StreamWriter("leaderboardSeason2.txt"))
            {
                writer.WriteLine($"Embark Logo: {client.Image.GetUrl(EmbarkImage.Embark)}\n");
                foreach (var entry in leaderboardSeason)
                {
                    writer.WriteLine($"{entry.Name}");
                    writer.WriteLine($" Rank Image Url: {client.League.GetImageUrl(entry.League, LeagueImageType.Full)}");
                }
            }
            using (var writer = new StreamWriter("leaderboardPlatformPush.txt"))
            {
                writer.WriteLine($"{leaderboardPlatformPush.Total}km / {leaderboardPlatformPush.Goal}km");
                foreach (var entry in leaderboardPlatformPush.Entries)
                {
                    writer.WriteLine($"{entry.Name} : {entry.Rank} : {entry.Distance}km");
                }
            }
        }
    }
}