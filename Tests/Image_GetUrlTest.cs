using TheFinals.NET.Enums;
using TheFinals.NET;
using TheFinals.NET.Enums.Image;

namespace Tests
{
    public class Image_GetUrlTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();

        [Fact]
        public void GetUrlTest_AllLeagues()
        {
            foreach (EmbarkImage image in Enum.GetValues(typeof(EmbarkImage)))
            {
                var imageUrl = _client.Image.GetUrl(image);
                Assert.NotNull(imageUrl); 
                Assert.StartsWith("https://storage.googleapis.com/embark-discovery-leaderboard/img", imageUrl);
            }
        }
    }
}
