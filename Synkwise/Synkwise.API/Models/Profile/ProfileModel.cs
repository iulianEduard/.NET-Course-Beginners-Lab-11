using System.ComponentModel.DataAnnotations;
using Synkwise.API.Models.Contact;

namespace Synkwise.API.Models.Profile
{
    public class ProfileModel : ContactableModel
    {
        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public int ContactId { get; set; }
    }
}