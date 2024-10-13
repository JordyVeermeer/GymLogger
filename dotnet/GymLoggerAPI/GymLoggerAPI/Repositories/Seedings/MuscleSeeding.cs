using GymLoggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymLoggerAPI.Repositories.Seedings
{
    public class MuscleSeeding : IEntityTypeConfiguration<Muscle>
    {
        public void Configure(EntityTypeBuilder<Muscle> builder)
        {
            builder.HasData(
                new Muscle { Id = 1, Name = "Chest" },
                new Muscle { Id = 2, Name = "Biceps" },
                new Muscle { Id = 3, Name = "Triceps" },
                new Muscle { Id = 4, Name = "Quadriceps" },
                new Muscle { Id = 5, Name = "Calves" },
                new Muscle { Id = 6, Name = "Shoulders" },
                new Muscle { Id = 7, Name = "Lats" },
                new Muscle { Id = 8, Name = "Upper back" },
                new Muscle { Id = 9, Name = "Mid back" },
                new Muscle { Id = 10, Name = "Hamstrings" }
                );
        }
    }
}
