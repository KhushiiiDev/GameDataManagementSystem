namespace GameDataManagementSystem.Models
{
    public class PlayerProgress : BaseEntity
    {
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int HighScore { get; set; }
        public int TotalKills { get; set; }

        public override string Display()
        {
            return $"[Player #{Id}] {PlayerName} | Level: {Level} | HighScore: {HighScore} | Kills: {TotalKills}";
        }
    }
}