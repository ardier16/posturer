using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public List<ExerciseStep> Steps { get; set; }
    }
}
