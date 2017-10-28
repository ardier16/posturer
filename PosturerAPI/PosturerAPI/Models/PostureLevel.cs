using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class PostureLevel
    {
        public int PostureLevelID { get; set; }
        public float Level { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public int PatientID { get; set; }
    }
}
