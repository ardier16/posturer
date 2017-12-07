using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        [JsonIgnore]
        public List<ApplicationUser> Users { get; set; }
    }
}
