using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class ExerciseStep
    {
        public int ExerciseStepId { get; set; }
        public int StepNumber { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public Exercise Exercise { get; set; }
        [JsonIgnore]
        public int ExerciseId { get; set; }

    }
}
