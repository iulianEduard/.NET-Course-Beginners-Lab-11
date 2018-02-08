using System;
using System.Collections.Generic;

namespace Synkwise.Core.Models.PlanEngine
{
    public class Plan
    {
        public int ResidentId { get; set; }

        public int PlanId { get; set; }

        public int PlanTypeId { get; set; }

        public Guid ModifiedByUser { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? SubmittedOn { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public List<Section> PlanSections { get; set; }
    }

    public class Section
    {
        public int PlanSectionid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public int KeyId { get; set; }

        public SectionData PlanGroups { get; set; }
    }

    public class SectionData
    {
        public int ColSpan { get; set; }

        public List<PlanGroup> Groups { get; set; }
    }

    public class PlanGroup
    {
        public int KeyId { get; set; }

        public string Key { get; set; }

        public int OrderNumber { get; set; }

        public List<Input> Inputs { get; set; }
    }

    public class Input
    {
        public string Id { get; set; }

        public int PlanGroupId { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string Type { get; set; }

        public Options Options { get; set; }

        public string Format { get; set; }

        public string Data { get; set; }

        public int? MaxLength { get; set; }

        public string Icon { get; set; }

        public int ColSpan { get; set; }

        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        public string Provider { get; set; }

        public int ProviderId { get; set; }

        public int ProviderTypeId { get; set; }

        public string ProviderData { get; set; }
    }

    public class Options
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }

}
