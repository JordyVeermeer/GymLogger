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
            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllAsync();
            return exercises.Select(ex => ExerciseToDTO(ex));
        }

        public async Task<ExerciseDTO?> GetExerciseById(int id)
        {
            var ex = await _exerciseRepository.GetByIdAsync(id);
            return ex != null ? ExerciseToDTO(ex) : null;
        }

        public async Task<int> DeleteExerciseById(int id)
        {
            return await _exerciseRepository.DeleteByIdAsync(id);
        }
        
        public async Task<Exercise?> CreateExercise(BaseExerciseDTO exercise)
        {
            return await _exerciseRepository.CreateAsync(BaseDTOToExercise(exercise));
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

        private static Exercise BaseDTOToExercise(BaseExerciseDTO dto)
        {
            Exercise ex = new()
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            foreach (var muscleDTO in dto.Muscles)
            {
                ex.Muscles.Add(new Muscle() { Id = muscleDTO.Id, Name = muscleDTO.Name });
            }

            return ex;
        }

        /*private static Exercise DTOToExercise(ExerciseDTO dto)
        {
            Exercise ex = new()
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            foreach (var muscleDTO in dto.Muscles)
            {
                ex.Muscles.Add(new Muscle() { Id = muscleDTO.Id, Name = muscleDTO.Name });
            }

            return ex;
        }*/
    }
}
