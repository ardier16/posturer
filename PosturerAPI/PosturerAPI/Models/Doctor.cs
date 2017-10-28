using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string EMail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
