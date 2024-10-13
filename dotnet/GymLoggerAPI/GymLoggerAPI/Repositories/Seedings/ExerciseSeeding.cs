using GymLoggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymLoggerAPI.Repositories.Seedings
{
    public class ExerciseSeeding : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(
                new Exercise { ExerciseId=1, Name="Bench Press", Description="Push bar upwards with arms" },
                new Exercise { ExerciseId = 2, Name ="Barbell Squat", Description="Push bar upwards with legs"}
                );
        }
    }
}
