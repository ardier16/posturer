using System.Collections.Generic;

namespace PosturerAndroid.Models
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string UserId { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}