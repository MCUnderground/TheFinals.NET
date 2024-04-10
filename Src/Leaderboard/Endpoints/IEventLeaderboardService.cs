using System.Threading.Tasks;

namespace TheFinals.NET.Leaderboard.Endpoints
{
    public interface IEventLeaderboardService<T> where T : class
    {
        Task<T> GetAsync(int? count = null, string nameFilter = null);
    }
}