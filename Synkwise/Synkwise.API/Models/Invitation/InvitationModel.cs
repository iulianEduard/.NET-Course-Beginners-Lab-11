using System;
using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Invitation
{
    public class InvitationModel
    {
        public int Id { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Email max-length is 255")]
        public string EmailTo { get; set; }

        public string Code { get; set; }

        public int RoleId { get; set; }

        public DateTime GeneratedDate { get; set; }

        public DateTime? ConfirmationDate { get; set; }
        
        public DateTime? LastModifiedDate { get; set; }
    }
}
