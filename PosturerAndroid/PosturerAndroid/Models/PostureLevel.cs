using System;

namespace PosturerAndroid.Models
{
    public class PostureLevel
    {
        public int PostureLevelId { get; set; }
        public float Level { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}