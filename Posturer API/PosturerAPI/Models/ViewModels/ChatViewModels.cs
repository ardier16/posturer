using System;
using System.Collections.Generic;

namespace PosturerAPI.Models
{
    // Модели, возвращаемые действиями ChatController.

    public class MessageBindingModel
    {
        public string Text { get; set; }
    }

    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime SentDate { get; set; }
        public string UserName { get; set; }
    }

    public class ChatViewModel
    {
        public int ChatId { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
    }

}
