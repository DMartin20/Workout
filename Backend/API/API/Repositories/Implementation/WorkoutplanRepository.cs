using API.Context;
using API.Models.Domain;
using API.Models.DTO;
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

        public async Task<WorkoutPlan> CreateWorkoutPlanAsync(CreateWorkoutPlanDTO workoutPlanDTO, int userId)
        {

            var workoutplan = new WorkoutPlan
            {
                UserId = userId,
                WorkoutName = workoutPlanDTO.WorkoutName,
                Reps = workoutPlanDTO.Reps,
                Rest = workoutPlanDTO.Rest
            };
            await _appDbContext.WorkoutPlans.AddAsync(workoutplan);
            await _appDbContext.SaveChangesAsync();

            return workoutplan;
        }

        public async Task<bool> DeleteWorkoutPlanAsync(int Id)
        {
            try
            {

                if (await _appDbContext.WorkoutPlans
                    .FirstOrDefaultAsync(wp => wp.WorkoutId == Id) == null)
                {
                    // Ha a workout plan nem található, akkor visszatérünk hamis értékkel
                    return false;
                }

                var workoutplan = _appDbContext.WorkoutPlans.FirstOrDefaultAsync(wp => wp.WorkoutId == Id);
                _appDbContext.WorkoutPlans.Remove(await workoutplan);
                // Töröljük az eddigi kapcsolatokat a workout és az exercise között
                var existingWorkoutExercises = await _appDbContext.WorkoutExercises
                     .Where(we => we.WorkoutId == Id)
                     .ToListAsync();

                _appDbContext.WorkoutExercises.RemoveRange(existingWorkoutExercises);


                await _appDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while Deleting workout plan: {ex.Message}"); ;
            }
        }

        public async Task<IEnumerable<GetWorkoutPlanDTO>> GetAllWorkoutPlanAsync(int UserId)
        {
            return await _appDbContext.WorkoutPlans
                .Where(wp => wp.UserId == UserId)
        .Select(x => new GetWorkoutPlanDTO
        {
            WorkoutName = x.WorkoutName,
            Reps = x.Reps,
            Rest = x.Rest,
            Exercises = _appDbContext.WorkoutExercises
                        .Where(we => we.WorkoutId == x.WorkoutId)
                        .Select(we => new GetExerciseDTO
                        {

                            ExerciseName = _appDbContext.Exercises
                                            .Where(e => e.ExerciseId == we.ExerciseId)
                                            .Select(e => e.ExerciseName)
                                            .FirstOrDefault(),
                            Imagepath = _appDbContext.Exercises
                                            .Where(e => e.ExerciseId == we.ExerciseId)
                                            .Select(e => e.ImagePath)
                                            .FirstOrDefault(),
                            DifficultyName = _appDbContext.Exercises
                                                .Where(e => e.ExerciseId == we.ExerciseId)
                                                .Select(e => e.Difficulty.DifficultyName)
                                                .FirstOrDefault(),
                            TypeNames = _appDbContext.Exercises
                                            .Where(e => e.ExerciseId == we.ExerciseId)
                                            .SelectMany(e => e.ExerciseTypes)
                                            .Select(et => et.Type.Name)
                                            .ToList()
                        })
                        .ToList()
        })
        .ToListAsync();
        }

        public async Task<GetWorkoutPlanDTO> GetWorkoutPlanByIdAsync(int id)
        {
            return await _appDbContext.WorkoutPlans
                .Where(wp => wp.WorkoutId == id)
                .Select(x => new GetWorkoutPlanDTO
                {
                    WorkoutName = x.WorkoutName,
                    Reps = x.Reps,
                    Rest = x.Rest,
                    Exercises = _appDbContext.WorkoutExercises
                        .Where(we => we.WorkoutId == x.WorkoutId)
                        .Select(we => new GetExerciseDTO
                        {

                            ExerciseName = _appDbContext.Exercises
                                            .Where(e => e.ExerciseId == we.ExerciseId)
                                            .Select(e => e.ExerciseName)
                                            .FirstOrDefault(),
                            Imagepath = _appDbContext.Exercises
                                            .Where(e => e.ExerciseId == we.ExerciseId)
                                            .Select(e => e.ImagePath)
                                            .FirstOrDefault(),
                            DifficultyName = _appDbContext.Exercises
                                                .Where(e => e.ExerciseId == we.ExerciseId)
                                                .Select(e => e.Difficulty.DifficultyName)
                                                .FirstOrDefault(),
                            TypeNames = _appDbContext.Exercises
                                            .Where(e => e.ExerciseId == we.ExerciseId)
                                            .SelectMany(e => e.ExerciseTypes)
                                            .Select(et => et.Type.Name)
                                            .ToList()
                        })
                        .ToList()
                }).FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateWorkoutPlanAsync(int Id, UpdatePlanDTO updatePlanDTO)
        {
            try
            {
                // Először lekérjük a workout plant az azonosító alapján
                var workoutPlan = await _appDbContext.WorkoutPlans
                    .FirstOrDefaultAsync(wp => wp.WorkoutId == Id);

                if (workoutPlan == null)
                {
                    // Ha a workout plan nem található, akkor visszatérünk hamis értékkel
                    return false;
                }

                // Frissítjük a workout plan nevét
                workoutPlan.WorkoutName = updatePlanDTO.WorkoutName;
                workoutPlan.Reps = updatePlanDTO.Reps;
                workoutPlan.Rest = updatePlanDTO.Rest;

                // Ellenőrizzük, hogy az exerciseIds nem üres
                if (updatePlanDTO.ExerciseIds != null && updatePlanDTO.ExerciseIds.Any())
                {
                    // Töröljük az eddigi kapcsolatokat a workout és az exercise között
                    var existingWorkoutExercises = await _appDbContext.WorkoutExercises
                        .Where(we => we.WorkoutId == Id)
                        .ToListAsync();

                    _appDbContext.WorkoutExercises.RemoveRange(existingWorkoutExercises);

                    // Majd hozzáadjuk az új gyakorlatokat
                    for (int i = 0; i < updatePlanDTO.ExerciseIds.Count; i++)
                    {
                        var exerciseId = updatePlanDTO.ExerciseIds[i];
                        var count = updatePlanDTO.Counts[i];

                        _appDbContext.WorkoutExercises.Add(new WorkoutExercise
                        {
                            WorkoutId = workoutPlan.WorkoutId,
                            ExerciseId = exerciseId,
                            Count = count
                        });
                    }
                }

                // Mentjük az adatbázisba a módosításokat
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Hiba esetén dobunk egy kivételt vagy visszatérünk hamis értékkel
                // Ezt a részt az alkalmazásod igényeinek megfelelően alakíthatod
                throw new Exception($"An error occurred while updating workout plan: {ex.Message}");
            }
        }

    }
}
