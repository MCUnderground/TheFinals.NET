using TheFinals.NET;
using TheFinals.NET.Enums;
using TheFinals.NET.Enums.Image;

namespace Tests
{
    public class Image_GetAsyncTest
    {
        private readonly TheFinalsClient _client = new TheFinalsClient();
        [Fact]
        public async Task GetAsyncTest_AllLeagues()
        {
            foreach (EmbarkImage image in Enum.GetValues(typeof(EmbarkImage)))
            {
                var imageData = await _client.Image.GetAsync(image);
                Assert.NotNull(imageData);
                Assert.IsType<byte[]>(imageData);
            }
        }
    }
}
