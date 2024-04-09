namespace API.Models.DTO
{
    public class CreateWorkoutPlanDTO
    {
        public string WorkoutName { get; set; }

        public int Rest { get; set; }

        public int Reps { get; set; }
    }
}
