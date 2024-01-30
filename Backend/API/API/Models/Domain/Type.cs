using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }

        public string Name { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
