using System;
using GameDataManagementSystem.Models;
using GameDataManagementSystem.Services;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Utilities
{  
    public static class MenuRenderer
    {
        public static void RunMainMenu(
            WeaponService weaponService,
            PowerUpService powerService,
            EnemyService enemyService,
            PlayerService playerService,
            IRandomDataGenerator generator,
            IDataStore dataStore)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("   GAME DATA MANAGEMENT SYSTEM  ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Weapon Management");
                Console.WriteLine("2. PowerUp Management");
                Console.WriteLine("3. Enemy Management");
                Console.WriteLine("4. Player Progress Management");
                Console.WriteLine("5. Random Data Generator");
                Console.WriteLine("6. Save All Data");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1": ManageWeapons(weaponService); break;
                    case "2": ManagePowerUps(powerService); break;
                    case "3": ManageEnemies(enemyService); break;
                    case "4": ManagePlayers(playerService); break;
                    case "5": ManageRandomGenerator(generator); break;
                    case "6":
                        dataStore.Save();
                        Console.WriteLine("Data saved!");
                        Pause();
                        break;
                    case "0": return;
                    default: Console.WriteLine("Invalid input."); Pause(); break;
                }
            }
        }

        // -------------------------------------------------------------
        // 🔫 WEAPONS MENU
        // -------------------------------------------------------------
        private static void ManageWeapons(WeaponService weapons)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ WEAPON MANAGEMENT ------");
                Console.WriteLine("1. List Weapons");
                Console.WriteLine("2. Add Weapon");
                Console.WriteLine("3. Delete Weapon");
                Console.WriteLine("4. Filter by Rarity");
                Console.WriteLine("5. Top Damage Weapons");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var w in weapons.GetAll())
                            Console.WriteLine(w.Display());
                        Pause();
                        break;

                    case "2":
                        AddWeapon(weapons);
                        break;

                    case "3":
                        DeleteEntity(weapons);
                        break;

                    case "4":
                        Console.Write("Enter rarity: ");
                        var r = Console.ReadLine();
                        foreach (var w in weapons.FilterByRarity(r))
                            Console.WriteLine(w.Display());
                        Pause();
                        break;

                    case "5":
                        Console.Write("How many? ");
                        int n = int.Parse(Console.ReadLine());
                        foreach (var w in weapons.TopDamage(n))
                            Console.WriteLine(w.Display());
                        Pause();
                        break;

                    case "0": return;
                }
            }
        }

        private static void AddWeapon(WeaponService weapons)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Damage: ");
            int dmg = int.Parse(Console.ReadLine());
            Console.Write("Fire Rate: ");
            double rate = double.Parse(Console.ReadLine());
            Console.Write("Rarity: ");
            string rarity = Console.ReadLine();

            weapons.Add(new Weapon
            {
                Name = name,
                Damage = dmg,
                FireRate = rate,
                Rarity = rarity
            });

            Console.WriteLine("Weapon added!");
            Pause();
        }

        // -------------------------------------------------------------
        // 💊 POWERUPS MENU
        // -------------------------------------------------------------
        private static void ManagePowerUps(PowerUpService power)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ POWERUP MANAGEMENT ------");
                Console.WriteLine("1. List PowerUps");
                Console.WriteLine("2. Add PowerUp");
                Console.WriteLine("3. Delete PowerUp");
                Console.WriteLine("4. Filter by Rarity");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var p in power.GetAll())
                            Console.WriteLine(p.Display());
                        Pause();
                        break;

                    case "2":
                        AddPowerUp(power);
                        break;

                    case "3":
                        DeleteEntity(power);
                        break;

                    case "4":
                        Console.Write("Rarity: ");
                        string r = Console.ReadLine();
                        foreach (var p in power.SearchByRarity(r))
                            Console.WriteLine(p.Display());
                        Pause();
                        break;

                    case "0": return;
                }
            }
        }

        private static void AddPowerUp(PowerUpService power)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Effect: ");
            string effect = Console.ReadLine();
            Console.Write("Duration (s): ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Rarity: ");
            string rarity = Console.ReadLine();

            power.Add(new PowerUp
            {
                Name = name,
                Effect = effect,
                DurationSeconds = duration,
                Rarity = rarity
            });

            Console.WriteLine("PowerUp added!");
            Pause();
        }

        // -------------------------------------------------------------
        // 👹 ENEMIES MENU
        // -------------------------------------------------------------
        private static void ManageEnemies(EnemyService enemies)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ ENEMY MANAGEMENT ------");
                Console.WriteLine("1. List Enemies");
                Console.WriteLine("2. Add Enemy");
                Console.WriteLine("3. Delete Enemy");
                Console.WriteLine("4. Filter by Difficulty");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var e in enemies.GetAll())
                            Console.WriteLine(e.Display());
                        Pause();
                        break;

                    case "2":
                        AddEnemy(enemies);
                        break;

                    case "3":
                        DeleteEntity(enemies);
                        break;

                    case "4":
                        Console.Write("Difficulty: ");
                        string d = Console.ReadLine();
                        foreach (var e in enemies.FilterByDifficulty(d))
                            Console.WriteLine(e.Display());
                        Pause();
                        break;

                    case "0": return;
                }
            }
        }

        private static void AddEnemy(EnemyService enemies)
        {
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Health: ");
            int hp = int.Parse(Console.ReadLine());
            Console.Write("Damage: ");
            int dmg = int.Parse(Console.ReadLine());
            Console.Write("Difficulty: ");
            string diff = Console.ReadLine();

            enemies.Add(new Enemy
            {
                Type = type,
                Health = hp,
                Damage = dmg,
                Difficulty = diff
            });

            Console.WriteLine("Enemy added!");
            Pause();
        }

        // -------------------------------------------------------------
        // 🎮 PLAYER MENU
        // -------------------------------------------------------------
        private static void ManagePlayers(PlayerService players)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ PLAYER PROGRESS ------");
                Console.WriteLine("1. List Players");
                Console.WriteLine("2. Add Player");
                Console.WriteLine("3. Delete Player");
                Console.WriteLine("4. Find Player by Name");
                Console.WriteLine("5. Top High Scores");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var p in players.GetAll())
                            Console.WriteLine(p.Display());
                        Pause();
                        break;

                    case "2":
                        AddPlayer(players);
                        break;

                    case "3":
                        DeleteEntity(players);
                        break;

                    case "4":
                        Console.Write("Enter name: ");
                        var name = Console.ReadLine();
                        foreach (var p in players.SearchByName(name))
                            Console.WriteLine(p.Display());
                        Pause();
                        break;

                    case "5":
                        Console.Write("How many? ");
                        int n = int.Parse(Console.ReadLine());
                        foreach (var p in players.TopHighScore(n))
                            Console.WriteLine(p.Display());
                        Pause();
                        break;

                    case "0": return;
                }
            }
        }

        private static void AddPlayer(PlayerService players)
        {
            Console.Write("Player Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: ");
            int level = int.Parse(Console.ReadLine());
            Console.Write("High Score: ");
            int high = int.Parse(Console.ReadLine());
            Console.Write("Total Kills: ");
            int kills = int.Parse(Console.ReadLine());

            players.Add(new PlayerProgress
            {
                PlayerName = name,
                Level = level,
                HighScore = high,
                TotalKills = kills
            });

            Console.WriteLine("Player added!");
            Pause();
        }

        // -------------------------------------------------------------
        // 🎲 RANDOM DATA GENERATOR MENU
        // -------------------------------------------------------------
        private static void ManageRandomGenerator(IRandomDataGenerator generator)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ RANDOM DATA GENERATOR ------");
                Console.WriteLine("1. Generate Weapons");
                Console.WriteLine("2. Generate PowerUps");
                Console.WriteLine("3. Generate Enemies");
                Console.WriteLine("4. Generate Players");
                Console.WriteLine("0. Back");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        GenerateRandom(generator.SeedWeapons, "weapons");
                        break;
                    case "2":
                        GenerateRandom(generator.SeedPowerUps, "powerups");
                        break;
                    case "3":
                        GenerateRandom(generator.SeedEnemies, "enemies");
                        break;
                    case "4":
                        GenerateRandom(generator.SeedPlayers, "players");
                        break;
                    case "0": return;
                }
            }
        }

        private static void GenerateRandom(Action<int, int> generator, string label)
        {
            Console.Write($"How many {label}? ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Seed (-1 = random): ");
            int seed = int.Parse(Console.ReadLine());

            generator(count, seed);
            Console.WriteLine($"Generated {count} {label}!");
            Pause();
        }

        // -------------------------------------------------------------
        // 🛠 SHARED UTILITY
        // -------------------------------------------------------------
        private static void DeleteEntity<T>(IRepository<T> service) where T : BaseEntity
        {
            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            service.Delete(id);
            Console.WriteLine("Deleted!");
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}