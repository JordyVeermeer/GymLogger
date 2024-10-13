namespace GymLoggerAPI.Models
{
    public class Exercise
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Muscle>? Muscles { get; set; }
    }
}
