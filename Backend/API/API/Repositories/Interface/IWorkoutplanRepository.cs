using API.Models.Domain;
using API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interface
{
    public interface IWorkoutplanRepository
    {

        Task<IEnumerable<GetWorkoutPlanDTO>> GetAllWorkoutPlanAsync(int UserId);

        Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int id);

        Task<bool> DeleteWorkoutPlanAsync(int id);

        Task<bool> UpdateWorkoutPlanAsync(int id, UpdatePlanDTO updatePlanDTO);

        Task<WorkoutPlan> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan);
    }
}
