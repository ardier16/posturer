using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosturerAPI.Models
{
    public class UserChat
    {
        public int UserChatId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Chat Chat { get; set; }
        public int ChatId { get; set; }

    }
}
