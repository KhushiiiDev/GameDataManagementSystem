namespace GameDataManagementSystem.Models

{
    public class Weapon : BaseEntity
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public double FireRate { get; set; }
        public string Rarity { get; set; }

        public override string Display()
        {
            return $"[Weapon #{Id}] {Name} | Damage: {Damage} | FireRate: {FireRate:F2} | Rarity: {Rarity}";
        }
    }
}