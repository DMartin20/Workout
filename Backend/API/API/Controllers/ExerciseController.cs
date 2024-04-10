using API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        [Authorize]
        [HttpGet("GetExercise")]
        public async Task<IActionResult> GetExerciseById(int exersizeId)
        {
            try
            {
                var exercise = await _exerciseRepository.GetExerciseAsync(exersizeId);
                return Ok(exercise);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Inernal Server Error: {ex.Message}!");
            }
        }
        [Authorize]
        [HttpGet("GetAllExercise")]
        public async Task<IActionResult> GetAllExercise()
        {
            try
            {
                var exercises = await _exerciseRepository.GetAllExercisesAsync();
                return Ok(exercises);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
