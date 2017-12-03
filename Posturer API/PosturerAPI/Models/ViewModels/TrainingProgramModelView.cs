using System;
using System.Collections.Generic;

namespace PosturerAPI.Models
{
    public class TrainingProgramModelView
    {
        public int TrainingProgramId { get; set; }
        public string UserId { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }
    }
}
