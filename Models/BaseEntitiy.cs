namespace GameDataManagementSystem.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string Display();
    }
}
