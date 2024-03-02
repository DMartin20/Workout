using API.Context;
using API.Models.Domain;
using API.Models.DTO;
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

        [HttpPost("createPlan")]
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

        [HttpGet("getUsersPLans/{userId}")]
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

        [HttpPost("updateWorkoutPlan/{workoutplanId}")]
        public async Task<IActionResult> UpdateWithExercises(int workoutplanId, UpdatePlanDTO updatePlanDTO)
        {
            try
            {
                var result = await _workoutplanRepository.UpdateWorkoutPlanAsync(workoutplanId, updatePlanDTO);

                if (result)
                {
                    return Ok("Update Successful!");
                }
                else
                {
                    return NotFound("Workout plan not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
