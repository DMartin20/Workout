using API.Models.Domain;

namespace API.Repositories.Interface
{
    public interface IWorkoutplanRepository
    {

        Task<IEnumerable<WorkoutPlan>> GetAllWorkoutPlanAsync(int UserId);

        Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int id);

        Task<bool> DeleteWorkoutPlanAsync(int id);

        Task<WorkoutPlan> UpdateWorkoutPlanAsync(int id, WorkoutPlan updatedWorkoutPlan);

        Task<WorkoutPlan> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan);
    }
}
