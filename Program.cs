using GameDataManagementSystem.Models;
using GameDataManagementSystem.Services;
using GameDataManagementSystem.Interfaces;
using GameDataManagementSystem.Utilities;

class Program
{
    static void Main()
    {
        var dataStore = new JsonDataStore();
        dataStore.Load();

        var weaponService = new WeaponService(dataStore.Weapons);
        var powerService = new PowerUpService(dataStore.PowerUps);
        var enemyService = new EnemyService(dataStore.Enemies);
        var playerService = new PlayerService(dataStore.Players);

        var generator = new RandomDataGenerator(
            weaponService, powerService, enemyService, playerService);

        MenuRenderer.RunMainMenu(
            weaponService, powerService, enemyService, playerService, generator, dataStore);
    }
}
