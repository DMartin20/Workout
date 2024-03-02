using API.Models.Domain;
using API.Models.DTO;

namespace API.Repositories.Interface
{
    public interface IExerciseRepository
    {
        Task<GetExerciseDTO> GetExerciseAsync(int exerciseId);

        Task<IEnumerable<GetExerciseDTO>> GetAllExercisesAsync();

    }
}
