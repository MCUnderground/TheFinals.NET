using TheFinals.NET;
using TheFinals.NET.Leaderboard.Models;

namespace Tests
{
    public class Leaderboard_Event_PlatformPush_GetAsyncTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();

        [Fact]
        public async Task GetAsyncTest()
        {
            var leaderboardEntries = await _client.Leaderboards.PlatformPushEvent.GetAsync();
            Assert.IsType<PlatformPushEventLeaderboard>(leaderboardEntries);
        }
    }

}