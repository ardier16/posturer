using System;
using System.Collections.Generic;

namespace PosturerAPI.Models
{

    public class ExerciseViewModel
    {
        public int ExerciseId { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public List<ExerciseStepViewModel> Steps { get; set; }
    }

    public class ExerciseStepViewModel
    {
        public int StepNumber { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }

}
