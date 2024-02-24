namespace API.Models.Domain
{
    public class ExerciseType
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
