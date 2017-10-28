using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class PatientMessage
    {
        public int PatientMessageID { get; set; }
        public Chat Chat { get; set; }
        public int ChatID { get; set; }
        public string Text { get; set; }
        public DateTime SentDate { get; set; }

        public Patient Patient { get; set; }
        public int? PatientID { get; set; }
    }
}
