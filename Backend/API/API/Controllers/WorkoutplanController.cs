using API.Models.Domain;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutplanController : ControllerBase
    {
        private readonly IWorkoutplanRepository _workoutplanRepository;

        public WorkoutplanController(IWorkoutplanRepository workoutplanRepository)
        {
            _workoutplanRepository = workoutplanRepository;
        }

        [HttpPost("CreatePlan")]
        public async Task<IActionResult> CreateNewPlan([FromBody] WorkoutPlan plan)
        {
            try
            {
                var createdPlan = await _workoutplanRepository.CreateWorkoutPlanAsync(plan);
                return Ok(createdPlan);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex.Message}!");
            }
        }

        [HttpGet("GetUsersPLans/{userId}")]
        public async Task<IActionResult> GetAllUserPlans(int userId)
        {
            try
            {
                var workouts = await _workoutplanRepository.GetAllWorkoutPlanAsync(userId);
                return Ok(workouts);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex.Message}!");
            }
        }
    }
}
