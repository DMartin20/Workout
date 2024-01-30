using Microsoft.EntityFrameworkCore;

namespace API.Models.Domain
{
    
    public class WorkoutExercise
    {
        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }

        public int Count { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }

        public Exercise Exercise { get; set; }
    }
}
