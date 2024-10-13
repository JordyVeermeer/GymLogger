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

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }
    }
}
