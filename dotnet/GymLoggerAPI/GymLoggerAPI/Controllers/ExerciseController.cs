﻿using GymLoggerAPI.DTOS;
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
        public async Task<IEnumerable<ExerciseDTO>> GetExercises()
        {
            return await ExerciseService.GetExercises();
        }

        [HttpGet]
        [Route("{exerciseId}")]
        public Task<ExerciseDTO?> GetExerciseById(int exerciseId) 
        {
            var res = ExerciseService.GetExerciseById(exerciseId);
            return res ?? null!;
        }
    }
}
