namespace GymLoggerAPI.DTOS
{
    public class ExerciseDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<MuscleDTO> Muscles { get; set; } = [];

        /*public ExerciseDTO(string name, string? description)
        {
            Name = name;
            Description = description;
        }*/
    }
}
