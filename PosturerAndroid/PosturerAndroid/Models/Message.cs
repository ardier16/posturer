using System;

namespace PosturerAndroid.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime SentDate { get; set; }
        public string UserName { get; set; }
    }
}