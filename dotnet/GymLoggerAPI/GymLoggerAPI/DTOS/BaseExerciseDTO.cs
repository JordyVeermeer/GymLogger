namespace GymLoggerAPI.DTOS
{
    public class BaseExerciseDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<MuscleDTO> Muscles { get; set; } = [];
    }
}
