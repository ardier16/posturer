using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        public List<PatientMessage> PatientMessages { get; set; }
        public List<DoctorMessage> DoctorMessages { get; set; }
    }
}
