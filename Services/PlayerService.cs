using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Services
{
    public class PlayerService : BaseService<PlayerProgress>
    {
        public PlayerService(List<PlayerProgress> source) : base(source) { }

        public IEnumerable<PlayerProgress> SearchByName(string name) =>
            collection.Where(x => x.PlayerName.Contains(name ?? "", System.StringComparison.OrdinalIgnoreCase));

        public IEnumerable<PlayerProgress> TopHighScore(int n) =>
            collection.OrderByDescending(x => x.HighScore).Take(n);
    }
}
