using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class WorkoutPlan
    {
        [Key]
        public int WorkoutId { get; set; }

        public int UserId { get; set; }

        public string WorkoutName { get; set;}

        public int Rest {  get; set; }

        public int Reps { get; set; }

        public User User { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
