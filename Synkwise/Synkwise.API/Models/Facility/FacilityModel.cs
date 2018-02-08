using System.Collections.Generic;
using Synkwise.API.Models.Contact;
using Synkwise.API.Models.Resident;
using System;

namespace Synkwise.API.Models.Facility
{
    public class FacilityModel : ContactableModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProviderId { get; set; }

        public int? ContactId { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<ResidentIdentifier> Residents { get; set; }
    }
}