using GymLoggerAPI.Models;

namespace GymLoggerAPI.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAll();
    }
}
