using API.Models.Domain;

namespace API.Models.DTO
{
    public class GetWorkoutPlanDTO
    {
        public int WorkoutId { get; set; }

        public string WorkoutName { get; set; }

        public int Rest {  get; set; }

        public int Reps { get; set; }

        public List<GetExerciseDTO> Exercises { get; set; }
    }
}
