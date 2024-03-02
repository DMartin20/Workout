using API.Models.Domain;

namespace API.Models.DTO
{
    public class UpdatePlanDTO
    {
        public string WorkoutName { get; set; }

        public int Rest {  get; set; }

        public int Reps { get; set; }

        public List<int> ExerciseIds{ get; set; }

        public List<int> Counts { get; set; }
    }
}
