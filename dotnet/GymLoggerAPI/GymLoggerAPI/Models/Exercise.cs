namespace GymLoggerAPI.Models
{
    public class Exercise
    {
        public long ExerciseId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        //public ICollection<MuscleGroup>? MuscleGroup { get; set; }
    }
}
