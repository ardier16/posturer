using Newtonsoft.Json;
using System.Collections.Generic;

namespace PosturerAPI.Models.Entities
{
    public class Chat
    {
        public int ChatId { get; set; }
        [JsonIgnore]
        public List<ApplicationUser> Users { get; set; }
    }
}
