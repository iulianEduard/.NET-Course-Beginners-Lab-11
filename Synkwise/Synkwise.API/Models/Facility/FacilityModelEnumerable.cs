using System.Collections.Generic;

namespace Synkwise.API.Models.Facility
{
    public class FacilityModelEnumerable
    {
        public IEnumerable<FacilityModel> Data { get; set; }
        public int TotalCount { get; set; }
    }
}