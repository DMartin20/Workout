namespace API.Models.Domain
{
    public class Exercise
    {
        public int ExerciseId {  get; set; }

        public string ExerciseName { get; set;}

        public int DifficultyId { get; set; }

        public string ImagePath { get; set; }

        public Difficulty Difficulty { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
