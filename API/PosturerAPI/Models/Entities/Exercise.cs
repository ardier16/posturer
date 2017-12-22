using System.Collections.Generic;

namespace PosturerAPI.Models.Entities
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public List<ExerciseStep> Steps { get; set; }
    }
}
