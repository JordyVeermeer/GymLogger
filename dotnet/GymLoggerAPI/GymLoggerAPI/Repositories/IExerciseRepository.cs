using GymLoggerAPI.Models;

namespace GymLoggerAPI.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise?> GetByIdAsync(int id);
        Task<int> DeleteByIdAsync(int id);
        Task<Exercise?> CreateAsync(Exercise exercise);
        Task<Exercise> UpdateAsync(Exercise exercise);
    }
}
