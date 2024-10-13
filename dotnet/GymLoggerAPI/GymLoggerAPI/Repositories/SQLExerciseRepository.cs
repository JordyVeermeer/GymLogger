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

        public Task<Exercise> CreateAsync(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
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
