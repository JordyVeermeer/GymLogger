using GymLoggerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymLoggerAPI.Repositories
{
    public class SQLExerciseRepository : IExerciseRepository
    {
        private readonly GymLoggerContext _context;

        public SQLExerciseRepository(GymLoggerContext context) 
        {
            _context = context;
        }

        public async Task<Exercise?> CreateAsync(Exercise exercise)
        {
            List<Muscle> musclesTargeted = [];

            foreach (Muscle m in exercise.Muscles) 
            {
                var muscle = _context.Muscles.Where(mu => mu.Id == m.Id).FirstOrDefault();
                if (muscle !=  null)
                {
                    musclesTargeted.Add(muscle);
                }
            }

            exercise.Muscles = musclesTargeted;

            await _context.AddAsync(exercise);
            int res = _context.SaveChanges();
            
            return res > 0 ? exercise : null;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await _context.Exercises.Where(e => e.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.Include(e => e.Muscles).ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.Include(e => e.Muscles).Where(ex => ex.Id == id).FirstOrDefaultAsync();
        }

        public Task<Exercise> UpdateAsync(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
