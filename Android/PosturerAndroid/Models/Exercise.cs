using System.Collections.Generic;

namespace PosturerAndroid.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public List<ExerciseStep> Steps { get; set; }
    }

    public class ExerciseStep
    {
        public int StepNumber { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}