namespace GameDataManagementSystem.Interfaces
{
    public interface IRandomDataGenerator
    {
        void SeedWeapons(int count, int seed = -1);
        void SeedPowerUps(int count, int seed = -1);
        void SeedEnemies(int count, int seed = -1);
        void SeedPlayers(int count, int seed = -1);
    }
}