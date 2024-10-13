using GymLoggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymLoggerAPI.Repositories.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercise");

            builder.HasKey(ex => ex.Id);

            builder.Property(ex => ex.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ex => ex.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(ex => ex.Name)
                .IsUnique();

            builder.Property(ex => ex.Description)
                .HasMaxLength(255);

            // Relations

            builder.HasMany(ex => ex.Muscles)
                .WithMany(m => m.Exercises)
                .UsingEntity<ExerciseMuscle>();
        }
    }
}
