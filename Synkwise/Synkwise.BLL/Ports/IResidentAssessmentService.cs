using Synkwise.Core.Models.Resident.Assessment;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IResidentAssessmentService
    {
        Task<Assessment> GetAssessementByResidentId(int id, int residentId);

        Task<int> CreateNewAssessmentForResident(Assessment assessment);

        Task<int> CloneAssessmentForResident(int originalAssessmentId, int residentId);

        Task UpdateAssessment(Assessment assessment);

        Task<ResidentRepresentatives> GetResidentRepresentatives(int residentId);

        Task SaveResidentRepresentatives(ResidentRepresentatives residentRepresentatives);

        Task<ResidentMedicalRepresentatives> GetResidentMedicalRepresentatives(int residentId);

        Task SaveResidentMedicalRepresentatives(ResidentMedicalRepresentatives residentMedicalRepresentatives);

        Task<ResidentPharmacyInformation> GetResidentPharmacyInformation(int residentId);

        Task SaveResidentPharmacyInformation(ResidentPharmacyInformation residentPharmacyInformation);

        Task<ResidentNurse> GetResidentNurse(int residentId);

        Task SaveResidentNurse(ResidentNurse residentNurse);

        Task<ResidentMedicalEquipment> GetResidentMedicalEquipment(int residentId);

        Task SaveResidentMedicalEquipment(ResidentMedicalEquipment residentMedicalEquipment);

        Task<ResidentInterview> GetResidentInterview(int residentId);

        Task SaveResidentInterview(ResidentInterview residentInterview);

        Task<ResidentDetailsActivities> GetResidentDetailsActivities(int residentId);

        Task SaveResidentDetailsActivities(ResidentDetailsActivities residentDetailsActivities);

        Task<ResidentDetailsBathing> GetResidentDetailsBathing(int residentId);

        Task SaveResidentDetailsBathing(ResidentDetailsBathing residentDetailsBathing);

        Task<ResidentDetailsCommunication> GetResidentDetailsCommunication(int residentId);

        Task SaveResidentDetailsCommunication(ResidentDetailsCommunication residentDetailsCommunication);

        Task<ResidentDetailsDressing> GetResidentDetailsDressing(int residentId);

        Task SaveResidentDetailsDressing(ResidentDetailsDressing residentDetailsDressing);

        Task<ResidentDetailsEating> GetResidentDetailsEating(int residentId);

        Task SaveResidentDetailsEating(ResidentDetailsEating residentDetailsEating);

        Task<ResidentDetailsEmergencyExiting> GetResidentDetailsEmergencyExiting(int residentId);

        Task SaveResidentDetailsEmergencyExiting(ResidentDetailsEmergencyExiting residentDetailsEmergencyExiting);

        Task<ResidentDetailsGrooming> GetResidentDetailsGrooming(int residentId);

        Task SaveResidentDetailsGrooming(ResidentDetailsGrooming residentDetailsGrooming);

        Task<ResidentDetailsMentalStatus> GetResidentDetailsMentalStatus(int residentId);

        Task SaveResidentDetailsMentalStatus(ResidentDetailsMentalStatus residentDetailsMentalStatus);

        Task<ResidentDetailsMobility> GetResidentDetailsMobility(int residentId);

        Task SaveResidentDetailsMobility(ResidentDetailsMobility residentDetailsMobility);

        Task<ResidentDetailsNightNeeds> GetResidentDetailsNightNeeds(int residentId);

        Task SaveResidentDetailsNightNeeds(ResidentDetailsNightNeeds residentDetailsNightNeeds);

        Task<ResidentDetailsToileting> GetResidentDetailsToileting(int residentId);

        Task SaveResidentDetailsToileting(ResidentDetailsToileting residentDetailsToileting);

        Task<ResidentSummaryOfInformation> GetResidentSummaryOfInformation(int residentId);

        Task SaveResidentSummaryOfInformation(ResidentSummaryOfInformation residentSummaryOfInformation);
    }
}
