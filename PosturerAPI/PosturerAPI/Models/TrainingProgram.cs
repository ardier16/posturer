using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class TrainingProgram
    {
        public int TrainingProgramID { get; set; }
        public Patient Patient { get; set; }
        public int PatientID { get; set; }
    }
}
