using API.Models.Domain;
using API.Models.DTO;

namespace API.Repositories.Interface
{
    public interface IExerciseRepository
    {
        Task<ExerciseDTO> GetExerciseAsync(int exerciseId);

        Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync();

        Task<Exercise> Create(Exercise exercise);
    }
}
