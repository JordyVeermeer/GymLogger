using GymLoggerAPI.DTOS;
using GymLoggerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymLoggerAPI.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService ExerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            ExerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDTO>>> GetExercises()
        {
            var res = await ExerciseService.GetExercises();
            return Ok(res);
        }

        [HttpGet]
        [Route("{exerciseId}")]
        public ActionResult<ExerciseDTO?> GetExerciseById(int exerciseId) 
        {
            var res = ExerciseService.GetExerciseById(exerciseId);
            if (res == null) 
            {
                return NotFound($"Exercise with id {exerciseId} was not found.");
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("{exerciseId}")]
        public async Task<IActionResult> DeleteExerciseById(int exerciseId)
        {
            bool removed = await ExerciseService.DeleteExerciseById(exerciseId) > 0;

            return removed ? Ok($"Exercise {exerciseId} removed succesfully.") : BadRequest($"Exercise {exerciseId} not found.");
        }

        [HttpPost]
        //[Route]
        public async Task<ActionResult<ExerciseDTO?>> CreateExercise(BaseExerciseDTO exerciseDTO)
        {
            var res = await ExerciseService.CreateExercise(exerciseDTO);
            if (res == null)
            {
                return BadRequest("The exercise could not be created");
            }

            Uri uri = new Uri($"https://www.example.com/api/exercises/{res.Id}");
            return Created(uri, res); 
        }
    }
}
