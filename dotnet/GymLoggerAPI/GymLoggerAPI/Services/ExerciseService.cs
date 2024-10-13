using GymLoggerAPI.DTOS;
using GymLoggerAPI.Models;
using GymLoggerAPI.Repositories;

namespace GymLoggerAPI.Services
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetExercises()
        {
            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAll();
            return exercises.Select(ex => ExerciseToDTO(ex));
        }

        private static ExerciseDTO ExerciseToDTO(Exercise ex)
        {
            return new ExerciseDTO
            {
                Name = ex.Name,
                Description = ex.Description,
            };
        }
    }
}
