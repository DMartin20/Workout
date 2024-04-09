using API.Models.Domain;
using API.Models.DTO;

namespace API.Repositories.Interface
{
    public interface IWorkoutplanRepository
    {

        Task<IEnumerable<GetWorkoutPlanDTO>> GetAllWorkoutPlanAsync(int UserId);

        Task<GetWorkoutPlanDTO> GetWorkoutPlanByIdAsync(int id);

        Task<bool> DeleteWorkoutPlanAsync(int id);

        Task<bool> UpdateWorkoutPlanAsync(int id, UpdatePlanDTO updatePlanDTO);

        Task<WorkoutPlan> CreateWorkoutPlanAsync(CreateWorkoutPlanDTO workoutPlan, int userId);
    }
}
