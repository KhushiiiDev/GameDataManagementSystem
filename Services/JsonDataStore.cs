using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;
using System.Text.Json;

namespace GameDataManagementSystem.Services
{
    public class JsonDataStore : IDataStore
    {
        public List<Weapon> Weapons { get; private set; } = new();
        public List<PowerUp> PowerUps { get; private set; } = new();
        public List<Enemy> Enemies { get; private set; } = new();
        public List<PlayerProgress> Players { get; private set; } = new();

        private JsonSerializerOptions options = new() { WriteIndented = true };
        private const string weaponsFile = "weapons.json";
        private const string powerupsFile = "powerups.json";
        private const string enemiesFile = "enemies.json";
        private const string playersFile = "players.json";

        public void Load()
        {
            Weapons = LoadList<Weapon>(weaponsFile);
            PowerUps = LoadList<PowerUp>(powerupsFile);
            Enemies = LoadList<Enemy>(enemiesFile);
            Players = LoadList<PlayerProgress>(playersFile);
        }

        public void Save()
        {
            SaveList(weaponsFile, Weapons);
            SaveList(powerupsFile, PowerUps);
            SaveList(enemiesFile, Enemies);
            SaveList(playersFile, Players);
        }

        private List<T> LoadList<T>(string file) =>
            File.Exists(file)
            ? JsonSerializer.Deserialize<List<T>>(File.ReadAllText(file), options)
            : new List<T>();

        private void SaveList<T>(string file, List<T> list)
        {
            File.WriteAllText(file, JsonSerializer.Serialize(list, options));
        }
    }
}