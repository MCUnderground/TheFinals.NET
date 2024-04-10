using TheFinals.NET.Enums;
using TheFinals.NET;
using TheFinals.NET.Leagues.Enums;

namespace Tests
{
    public class League_GetImageUrlTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();

        [Fact]
        public void GetImageUrlTest_AllLeagues()
        {
            foreach (League league in Enum.GetValues(typeof(League)))
            {
                foreach (LeagueImageType imageType in Enum.GetValues(typeof(LeagueImageType)))
                {
                    var imageUrl = _client.League.GetImageUrl(league, imageType);
                    Assert.NotNull(imageUrl);
                    Assert.StartsWith("https://storage.googleapis.com/embark-discovery-leaderboard/img", imageUrl);
                }
            }
        }
    }
}
