using GymLoggerAPI.DTOS;
using GymLoggerAPI.Models;
using GymLoggerAPI.Repositories;
using System.Reflection.Metadata.Ecma335;

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
            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllAsync();
            return exercises.Select(ex => ExerciseToDTO(ex));
        }

        public async Task<ExerciseDTO?> GetExerciseById(int id)
        {
            var ex = await _exerciseRepository.GetByIdAsync(id);
            return ex != null ? ExerciseToDTO(ex) : null;
        }

        /*
         * 
         * PRIVATE METHODS
         * 
         */
        private static ExerciseDTO ExerciseToDTO(Exercise ex)
        {
            ExerciseDTO dto = new()
            {
                Id = ex.Id,
                Name = ex.Name,
                Description = ex.Description,
            };

            foreach (var muscle in ex.Muscles)
            {
                dto.Muscles.Add(new MuscleDTO { Id = muscle.Id, Name = muscle.Name});
            }

            return dto;
        }
    }
}
