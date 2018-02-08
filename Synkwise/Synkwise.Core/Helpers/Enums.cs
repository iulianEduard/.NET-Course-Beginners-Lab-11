namespace Synkwise.Core.Helpers
{
    public enum StatusCode
    {
        Error = -1,
        Success = 0,
        Warning = 1
    }

    public enum ClaimTypeEnum
    {
        Provider,
        Facility,
        Resident
    }

    public enum FileType
    {
        Photo,
        Document
    }

    public enum UserStatus
    {
        Active = 1,
        InActive = 2
    }

    public enum ContactType
    {
        User = 1,
        Facility,
        Provider,
        Resident,
        ResponsiblePerson,
        PrimaryPhysician,
        Specialist,
        Dentist,
        HomeHealth,
        Pharmacy,
        MedicalEquipmentSupplier,
        CaseManager,
        EmergencyContact
    }
}
