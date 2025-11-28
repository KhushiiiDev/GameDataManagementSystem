using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Services
{
    public class RandomDataGenerator : IRandomDataGenerator
    {
        private readonly WeaponService weapons;
        private readonly PowerUpService powerups;
        private readonly EnemyService enemies;
        private readonly PlayerService players;

        public RandomDataGenerator(
            WeaponService w,
            PowerUpService p,
            EnemyService e,
            PlayerService pl)
        {
            weapons = w;
            powerups = p;
            enemies = e;
            players = pl;
        }

        public void SeedWeapons(int count, int seed = -1)
        {
            Random rand = new Random(seed < 0 ? Guid.NewGuid().GetHashCode() : seed);

            string[] names = { "Laser Gun", "Plasma Rifle", "Pulse Cannon" };
            string[] rarity = { "Common", "Rare", "Epic", "Legendary" };

            for (int i = 0; i < count; i++)
            {
                weapons.Add(new Weapon
                {
                    Name = names[rand.Next(names.Length)],
                    Damage = rand.Next(5, 150),
                    FireRate = rand.NextDouble() * 3 + 0.5,
                    Rarity = rarity[rand.Next(rarity.Length)]
                });
            }
        }

        // Implement for PowerUps, Enemies, Players...
        public void SeedPowerUps(int count, int seed = -1) { }
        public void SeedEnemies(int count, int seed = -1) { }
        public void SeedPlayers(int count, int seed = -1) { }
    }
}