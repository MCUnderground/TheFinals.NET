using TheFinals.NET;
using TheFinals.NET.Enums;

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
            var leaderboardSeason2 = await client.Leaderboard.GetAsync(LeaderboardVersion.Season2);

            if (leaderboardSeason2 == null)
            {
                Console.WriteLine("No leaderboard data was found.");
                return;
            }

            using (var writer = new StreamWriter("leaderboard.txt"))
            {
                foreach (var entry in leaderboardSeason2)
                {
                    writer.WriteLine($"{client.League.GetImageUrl(entry.League, LeagueImageType.Full)}");
                }
            }
        }
    }
}