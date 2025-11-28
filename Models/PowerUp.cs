namespace GameDataManagementSystem.Models
{
    public class PowerUp : BaseEntity
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public int DurationSeconds { get; set; }
        public string Rarity { get; set; }

        public override string Display()
        {
            return $"[PowerUp #{Id}] {Name} | Effect: {Effect} | Duration: {DurationSeconds}s | Rarity: {Rarity}";
        }
    }
}