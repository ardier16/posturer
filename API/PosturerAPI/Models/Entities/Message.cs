using Newtonsoft.Json;
using System;

namespace PosturerAPI.Models.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        [JsonIgnore]
        public Chat Chat { get; set; }
        public int ChatId { get; set; }

        public string Text { get; set; }
        public DateTime SentDate { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
