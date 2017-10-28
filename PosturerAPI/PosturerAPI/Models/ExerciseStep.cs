using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class ExerciseStep
    {
        public int ExerciseStepID { get; set; }
        public int StepNumber { get; set; }
        public string Text { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseID { get; set; }

    }
}
