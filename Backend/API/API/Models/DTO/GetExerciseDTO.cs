﻿using API.Models.Domain;

namespace API.Models.DTO
{
    public class GetExerciseDTO
    {
        public int Id { get; set; }

        public string ExerciseName { get; set; }

        public string DifficultyName { get; set; }

        public string Imagepath { get; set; }

        public List<string> TypeNames { get; set; }
    }
}
