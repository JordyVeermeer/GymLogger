using GymLoggerAPI.Models;
using GymLoggerAPI.Repositories.Configurations;
using GymLoggerAPI.Repositories.Seedings;
using Microsoft.EntityFrameworkCore;

namespace GymLoggerAPI.Repositories
{
    public class GymLoggerContext : DbContext
    {
        bool testMode = false;

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscle { get; set; }

        
        public GymLoggerContext(DbContextOptions<GymLoggerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new MuscleConfiguration());

            if (!testMode)
            {
                modelBuilder.ApplyConfiguration(new MuscleSeeding());
                modelBuilder.ApplyConfiguration(new ExerciseSeeding());
                modelBuilder.ApplyConfiguration(new ExerciseMuscleSeeding());

                
            }
        }

    }
}
