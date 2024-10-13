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

        
        public GymLoggerContext(DbContextOptions<GymLoggerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());

            if (!testMode)
            {
                modelBuilder.ApplyConfiguration(new ExerciseSeeding());
            }
        }

    }
}
