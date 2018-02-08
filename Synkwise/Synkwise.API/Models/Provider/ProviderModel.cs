using System;
using Synkwise.API.Models.Contact;

namespace Synkwise.API.Models.Provider
{
    public class ProviderModel : ContactableModel
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public int StatusID { get; set; }
    }
}