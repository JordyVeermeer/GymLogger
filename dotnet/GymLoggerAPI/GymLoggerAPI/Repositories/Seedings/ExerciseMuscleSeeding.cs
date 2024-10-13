using GymLoggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymLoggerAPI.Repositories.Seedings
{
    public class ExerciseMuscleSeeding : IEntityTypeConfiguration<ExerciseMuscle>
    {
        public void Configure(EntityTypeBuilder<ExerciseMuscle> builder)
        {
            builder.HasData(
                new ExerciseMuscle { ExerciseId = 1L, MuscleId = 1},
                new ExerciseMuscle { ExerciseId = 2L, MuscleId = 4},
                new ExerciseMuscle { ExerciseId = 2L, MuscleId = 10}
                );
        }
    }
}
