using TheFinals.NET;
using TheFinals.NET.Enums;
using TheFinals.NET.Models;

namespace Tests
{
    public class UnitGetAsyncTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();

        [Fact]
        public async Task GetAsyncTest_AllLeaderboardVersions()
        {
            foreach (LeaderboardVersion version in Enum.GetValues(typeof(LeaderboardVersion)))
            {
                var leaderboardEntries = await _client.Leaderboard.GetAsync(version);
                Assert.IsType<List<LeaderboardEntry>>(leaderboardEntries);
            }
        }

        [Fact]
        public async Task GetAsyncTest_AllPlatforms()
        {
            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                var leaderboardEntries = await _client.Leaderboard.GetAsync(LeaderboardVersion.Season2, platform);
                Assert.IsType<List<LeaderboardEntry>>(leaderboardEntries);
            }
        }

        [Fact]
        public async Task GetAsyncTest_Count()
        {
            var leaderboardEntries = await _client.Leaderboard.GetAsync(LeaderboardVersion.Season2, Platform.Crossplay, 10);
            Assert.True(leaderboardEntries.Count <= 10);
        }

        [Fact]
        public async Task GetAsyncTest_NameFilter()
        {
            string nameFilter = "TestPlayer";
            var leaderboardEntries = await _client.Leaderboard.GetAsync(LeaderboardVersion.Season2, Platform.Crossplay, null, nameFilter);
            Assert.All(leaderboardEntries, entry => Assert.Contains(nameFilter, entry.Name));
        }
    }

}