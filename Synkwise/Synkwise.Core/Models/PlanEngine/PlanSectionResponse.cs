using System;

namespace Synkwise.Core.Models.PlanEngine
{
    public class PlanSectionResponse
    {
        public int Id { get; set; }

        public int PlanDocumentId { get; set; }

        public int PlanSectionTemplateId { get; set; }

        public decimal? CompletedPercentage { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CreatedBy { get; set; }

        public int OrderNumber { get; set; }

        public int CategoryId { get; set; }

        public int Columns { get; set; }

        public int KeyId { get; set; }

        public string Key { get; set; }
    }
}
