using API.Context;
using API.Models.Domain;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation
{
    public class WorkoutplanRepository : IWorkoutplanRepository
    {
        private readonly AppDbContext _appDbContext;

        public WorkoutplanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<WorkoutPlan> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan)
        {
            await _appDbContext.WorkoutPlans.AddAsync(workoutPlan);
            await _appDbContext.SaveChangesAsync();

            return workoutPlan;
        }

        public async Task<bool> DeleteWorkoutPlanAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkoutPlan>> GetAllWorkoutPlanAsync(int UserId)
        {
            return await _appDbContext.WorkoutPlans
                .Where(wp => wp.UserId == UserId)
                .ToListAsync();
        }

        public async Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkoutPlan> UpdateWorkoutPlanAsync(int id, WorkoutPlan updatedWorkoutPlan)
        {
            throw new NotImplementedException();
        }
    }
}
