using System;

namespace Synkwise.Core.Models.PlanEngine
{
    public class PlanGroupResponse
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Key { get; set; }

        public DateTime? DateOfEntry { get; set; }

        public int PlanSectionValueId { get; set; }

        public int Position { get; set; }

        public int OrderNumber { get; set; }
    }
}
