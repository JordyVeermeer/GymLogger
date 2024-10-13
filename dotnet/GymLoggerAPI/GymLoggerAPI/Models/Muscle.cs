namespace GymLoggerAPI.Models
{
    public class Muscle
    {
        public long Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
