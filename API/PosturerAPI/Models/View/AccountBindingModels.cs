using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PosturerAPI.Models.View
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} must have at least {2} symbols.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Your new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangeUsernameBindingModel
    {
        [Required]
        public string UserName { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} must have at least {2} symbols.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        public string LoginProvider { get; set; }

        [Required]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "З{0} must have at least {2} symbols.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Your new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
