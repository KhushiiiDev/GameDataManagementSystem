using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Services
{
    public class EnemyService : BaseService<Enemy>
    {
        public EnemyService(List<Enemy> source) : base(source) { }

        public IEnumerable<Enemy> FilterByDifficulty(string diff) =>
            collection.Where(x => x.Difficulty.Equals(diff, System.StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Enemy> TopDamage(int n) =>
            collection.OrderByDescending(x => x.Damage).Take(n);
    }
}