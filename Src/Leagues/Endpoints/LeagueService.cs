using System;
using System.Net.Http;
using System.Threading.Tasks;
using TheFinals.NET.Leagues.Enums;

namespace TheFinals.NET.Leagues.Endpoints
{
    public interface ILeagueService
    {
        string GetImageUrl(League league, LeagueImageType imageType);

        Task<byte[]> GetImageAsync(League league, LeagueImageType imageType);
    }

    public class LeagueService : ILeagueService
    {
        private readonly HttpClient _httpClient;

        public LeagueService(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public string GetImageUrl(League league, LeagueImageType imageType)
        {
            var leagueString = league.ToString().Replace("1", "-1").Replace("2", "-2").Replace("3", "-3").Replace("4", "-4").ToLower();
            var url = imageType == LeagueImageType.Full
                ? $"https://storage.googleapis.com/embark-discovery-leaderboard/img/{leagueString}.png"
                : $"https://storage.googleapis.com/embark-discovery-leaderboard/img/thumbs/{leagueString}-thumb.png";
            return url;
        }

        public async Task<byte[]> GetImageAsync(League league, LeagueImageType imageType)
        {
            var url = GetImageUrl(league, imageType);
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }

            throw new Exception($"Failed to retrieve image for league {league}");
        }
    }
}