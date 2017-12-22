using System.Collections.Generic;

namespace PosturerAPI.Models.View
{
    public class TrainingProgramViewModel
    {
        public int TrainingProgramId { get; set; }
        public string UserId { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }
    }
}
