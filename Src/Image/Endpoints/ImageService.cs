using System;
using System.Net.Http;
using System.Threading.Tasks;
using TheFinals.NET.Enums.Image;

namespace TheFinals.NET.Image.Endpoints
{
    public interface IImageService
    {
        string GetUrl(EmbarkImage image);

        Task<byte[]> GetAsync(EmbarkImage image);
    }

    public class ImageService : IImageService
    {
        private readonly HttpClient _httpClient;

        public ImageService(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public string GetUrl(EmbarkImage image)
        {
            var url = $"https://storage.googleapis.com/embark-discovery-leaderboard/img/{image}.png";
            return url;
        }

        public async Task<byte[]> GetAsync(EmbarkImage image)
        {
            var url = GetUrl(image);
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }

            throw new Exception($"Failed to retrieve image for league {image}");
        }
    }
}