using System.Collections.Generic;

namespace Synkwise.Repository.Models.Facility
{
    public class FacilityEntityEnumerable
    {
        public IEnumerable<FacilityEntity> Data { get; set; }
        public int TotalCount { get; set; }
    }
}