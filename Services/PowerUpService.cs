using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Services
{
    public class PowerUpService : BaseService<PowerUp>
    {
        public PowerUpService(List<PowerUp> source) : base(source) { }

        public IEnumerable<PowerUp> SearchByRarity(string rarity) =>
            collection.Where(x => x.Rarity.Equals(rarity, System.StringComparison.OrdinalIgnoreCase));

        public IEnumerable<PowerUp> TopByDuration(int n) =>
            collection.OrderByDescending(x => x.DurationSeconds).Take(n);
    }
}