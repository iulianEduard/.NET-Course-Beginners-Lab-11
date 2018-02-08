using System;

namespace Synkwise.Core.Models.Facility
{
    public class Facility
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProviderId { get; set; }

        public int? ContactId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}