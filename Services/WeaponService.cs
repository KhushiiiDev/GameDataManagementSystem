using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Services
{
    public class WeaponService : BaseService<Weapon>
    {
        public WeaponService(List<Weapon> src) : base(src) { }

        public IEnumerable<Weapon> FilterByRarity(string rarity) =>
            collection.Where(w => w.Rarity.Equals(rarity, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Weapon> TopDamage(int n) =>
            collection.OrderByDescending(w => w.Damage).Take(n);
    }
}