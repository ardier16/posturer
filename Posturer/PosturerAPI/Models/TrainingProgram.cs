using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
