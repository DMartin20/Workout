using API.Context;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExerciseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Exercise> Create(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync()
        {
            return await _appDbContext.Exercises
                .Select(e => new ExerciseDTO
                {
                    ExerciseName = e.ExerciseName,
                    Imagepath = e.ImagePath,
                    DifficultyName = e.Difficulty.DifficultyName,
                    TypeNames = e.ExerciseTypes.Select(et => et.Type.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<ExerciseDTO> GetExerciseAsync(int exerciseId)
        {
            return await _appDbContext.Exercises
                .Where(e => e.ExerciseId == exerciseId)
                .Select(e => new ExerciseDTO
                {
                    ExerciseName = e.ExerciseName,
                    Imagepath = e.ImagePath,
                    DifficultyName = e.Difficulty.DifficultyName,
                    TypeNames = e.ExerciseTypes.Select(et => et.Type.Name).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
