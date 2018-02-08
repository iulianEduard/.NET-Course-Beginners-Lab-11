using System.Collections.Generic;

namespace Synkwise.Core.Models.Facility
{
    public class FacilityEnumerable
    {
        public IEnumerable<Facility> Data { get; set; }
        public int TotalCount { get; set; }
    }
}