using System;

namespace PosturerAPI.Models.View
{
    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public DateTime? RegistrationDate { get; set; }
    }
}
