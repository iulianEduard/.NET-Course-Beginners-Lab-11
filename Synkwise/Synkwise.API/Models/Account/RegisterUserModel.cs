using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Account
{
    public class RegisterUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is required!")]
        [MaxLength(25)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is required!")]
        [MaxLength(25)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text, ErrorMessage = "Cannot register without invitation code!")]
        public string InvitationCode { get; set; }
    }
}
