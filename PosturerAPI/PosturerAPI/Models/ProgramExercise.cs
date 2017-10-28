using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class ProgramExercise
    {
        public int ProgramExerciseID { get; set; }
        public Exercise Exercise { get; set; }
        public TrainingProgram TrainingProgram { get; set; }

        public int ExerciseID { get; set; }
        public int TrainingProgramID { get; set; }
    }
}
