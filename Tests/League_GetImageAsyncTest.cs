using TheFinals.NET;
using TheFinals.NET.Enums;

namespace Tests
{
    public class League_GetImageAsyncTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();
        [Fact]
        public async Task GetImageAsyncTest_AllLeagues()
        {
            foreach (League league in Enum.GetValues(typeof(League)))
            {
                foreach (LeagueImageType imageType in Enum.GetValues(typeof(LeagueImageType)))
                {
                    var imageData = await _client.League.GetImageAsync(league, imageType);
                    Assert.NotNull(imageData);
                    Assert.IsType<byte[]>(imageData);
                }
            }
        }
    }
}
