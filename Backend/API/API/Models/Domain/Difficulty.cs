using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class Difficulty
    {
        [Key]
        public int DifficultyId { get; set; }

        public string DifficultyName { get; set;}

        public List<Exercise> Exercises { get; set; }
    }
}
