namespace Synkwise.Core.Models.Resident.Assessment
{
    public class ResidentDetailsBathing : BaseAssessment
    {
        public bool NeedAssitance { get; set; }

        public bool SpecialEquipment { get; set; }

        public string Details { get; set; }
    }
}
