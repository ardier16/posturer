using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class DoctorMessage
    {
        public int DoctorMessageID { get; set; }
        public Chat Chat { get; set; }
        public int ChatID { get; set; }

        public string Text { get; set; }
        public DateTime SentDate { get; set; }

        public Doctor Doctor { get; set; }
        public int? DoctorID { get; set; }
    }
}
