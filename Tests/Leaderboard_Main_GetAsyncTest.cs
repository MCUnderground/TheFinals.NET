using TheFinals.NET;
using TheFinals.NET.Enums;
using TheFinals.NET.Leaderboard.Enums;
using TheFinals.NET.Leaderboard.Models;

namespace Tests
{
    public class Leaderboard_Main_GetAsyncTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();

        [Fact]
        public async Task GetAsyncTest_AllLeaderboardVersions()
        {
            foreach (LeaderboardVersion version in Enum.GetValues(typeof(LeaderboardVersion)))
            {
                var leaderboardEntries = await _client.Leaderboards.Main.GetAsync(version);
                Assert.IsType<List<LeaderboardEntry>>(leaderboardEntries);
            }
        }

        [Fact]
        public async Task GetAsyncTest_AllPlatforms()
        {
            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                var leaderboardEntries = await _client.Leaderboards.Main.GetAsync(LeaderboardVersion.Season2, platform);
                Assert.IsType<List<LeaderboardEntry>>(leaderboardEntries);
            }
        }

        [Fact]
        public async Task GetAsyncTest_Count()
        {
            var leaderboardEntries = await _client.Leaderboards.Main.GetAsync(LeaderboardVersion.Season2, Platform.Crossplay, 10);
            Assert.True(leaderboardEntries.Count <= 10);
        }

        [Fact]
        public async Task GetAsyncTest_NameFilter()
        {
            string nameFilter = "TestPlayer";
            var leaderboardEntries = await _client.Leaderboards.Main.GetAsync(LeaderboardVersion.Season2, Platform.Crossplay, null, nameFilter);
            Assert.All(leaderboardEntries, entry => Assert.Contains(nameFilter, entry.Name));
        }
    }

}