using Newtonsoft.Json;
using System;

namespace PosturerAPI.Models
{
    public class PostureLevel
    {
        public int PostureLevelId { get; set; }
        public float Level { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
