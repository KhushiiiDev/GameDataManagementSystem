namespace GameDataManagementSystem.Models
{
    public class Enemy : BaseEntity
    {
        public string Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public string Difficulty { get; set; }

        public override string Display()
        {
            return $"[Enemy #{Id}] {Type} | HP: {Health} | Damage: {Damage} | Difficulty: {Difficulty}";
        }
    }
}