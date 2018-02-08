using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Assessment;
using Synkwise.Core.Exceptions.Provider;
using Synkwise.Core.Models.Resident.Assessment;
using Synkwise.Repository.Models.Resident;
using Synkwise.Repository.Ports;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class ResidentAssessmentService : IResidentAssessmentService
    {
        #region Attributes

        private readonly IResidentAssessmentRepository _residentAssessmentRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public ResidentAssessmentService(IResidentAssessmentRepository residentAssessmentRepository)
        {
            _residentAssessmentRepository = residentAssessmentRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        #region CRUD Assessment

        public async Task<Assessment> GetAssessementByResidentId(int id, int residentId)
        {
            var assessmentEntity = await _residentAssessmentRepository.GetAssessementByResidentId(id, residentId);

            if (assessmentEntity == null)
                throw new AssessmentInternalServerErrorException("Cannot find assessment for resident!");

            var assessment = Mapper.Map<Assessment>(assessmentEntity);

            return assessment;
        }

        public async Task<int> CreateNewAssessmentForResident(Assessment assessment)
        {
            var assessmentEntity = Mapper.Map<AssessmentEntity>(assessment);

            if (assessmentEntity == null)
                throw new AssessmentInternalServerErrorException("Assessment save - Invalid object!");

            var assessmentId = await _residentAssessmentRepository.CreateNewAssessmentForResident(assessmentEntity);

            if (assessmentId == 0)
                throw new AssessmentInternalServerErrorException("Assessment save - Cannot save assessment!");

            return assessmentId;
        }

        public async Task<int> CloneAssessmentForResident(int originalAssessmentId, int residentId)
        {
            var newAssessmentId = await _residentAssessmentRepository.CloneAssessmentForResident(originalAssessmentId, residentId);

            if (newAssessmentId == 0)
                throw new AssessmentInternalServerErrorException("Assessment save - Could not create new instance of assessment!");

            return newAssessmentId;
        }

        public async Task UpdateAssessment(Assessment assessment)
        {
            var assessmentEntity = Mapper.Map<AssessmentEntity>(assessment);

            if (assessmentEntity == null)
                throw new AssessmentInternalServerErrorException("Assessment update - Invalid object");

            await _residentAssessmentRepository.UpdateAssessment(assessmentEntity);
        }

        #endregion CRUD Assessment

        #region Representatives

        public async Task<ResidentRepresentatives> GetResidentRepresentatives(int residentId)
        {
            var residentRepresentatives = await _residentAssessmentRepository.GetResidentReprezentatives(residentId);

            ValidateResidentRepresentatives(residentRepresentatives);

            return residentRepresentatives;
        }

        public async Task SaveResidentRepresentatives(ResidentRepresentatives residentReprezentatives)
        {
            await _residentAssessmentRepository.SaveResidentReprezentatives(residentReprezentatives);
        }

        #endregion Representatives

        #region Medical Representatives

        public async Task<ResidentMedicalRepresentatives> GetResidentMedicalRepresentatives(int residentId)
        {
            var medicalRepresentatives = await _residentAssessmentRepository.GetResidentMedicalRepresentatives(residentId);

            ValidateResidentMedicalRepresentatives(medicalRepresentatives);

            return medicalRepresentatives;
        }

        public async Task SaveResidentMedicalRepresentatives(ResidentMedicalRepresentatives residentMedicalRepresentatives)
        {
            await _residentAssessmentRepository.SaveResidentMedicalRepresentatives(residentMedicalRepresentatives);
        }

        #endregion Medical Representatives

        #region Pharmacy Information

        public async Task<ResidentPharmacyInformation> GetResidentPharmacyInformation(int residentId)
        {
            var pharmacyInformation = await _residentAssessmentRepository.GetResidentPharmacyInformation(residentId);

            ValidateResidentPharmacyInformation(pharmacyInformation);

            return pharmacyInformation;
        }

        public async Task SaveResidentPharmacyInformation(ResidentPharmacyInformation residentPharmacyInformation)
        {
            await _residentAssessmentRepository.SaveResidentPharmacyInformation(residentPharmacyInformation);
        }

        #endregion Pharmacy Information

        #region Nurse

        public async Task<ResidentNurse> GetResidentNurse(int residentId)
        {
            var residentNurse = await _residentAssessmentRepository.GetResidentNurse(residentId);

            ValidateResidentNurse(residentNurse);

            return residentNurse;
        }

        public async Task SaveResidentNurse(ResidentNurse residentNurse)
        {
            await _residentAssessmentRepository.SaveResidentNurse(residentNurse);
        }

        #endregion Nurse

        #region Medical Equipment

        public async Task<ResidentMedicalEquipment> GetResidentMedicalEquipment(int residentId)
        {
            var medicalEquipment = await _residentAssessmentRepository.GetResidentMedicalEquipment(residentId);

            ValidateResidentMedicalEquipment(medicalEquipment);

            return medicalEquipment;
        }

        public async Task SaveResidentMedicalEquipment(ResidentMedicalEquipment residentMedicalEquipment)
        {
            await _residentAssessmentRepository.SaveResidentMedicalEquipment(residentMedicalEquipment);
        }

        #endregion Medical Equipment

        #region Interview

        public async Task<ResidentInterview> GetResidentInterview(int residentId)
        {
            var interview = await _residentAssessmentRepository.GetResidentInterview(residentId);

            ValidateResidentInterview(interview);

            return interview;
        }

        public async Task SaveResidentInterview(ResidentInterview residentInterview)
        {
            await _residentAssessmentRepository.SaveResidentInterview(residentInterview);
        }

        #endregion Interview 

        #region Details Activities

        public async Task<ResidentDetailsActivities> GetResidentDetailsActivities(int residentId)
        {
            var detailsActivities = await _residentAssessmentRepository.GetResidentDetailsActivities(residentId);

            ValidateResidentDetailsActivities(detailsActivities);

            return detailsActivities;
        }

        public async Task SaveResidentDetailsActivities(ResidentDetailsActivities residentDetailsActivities)
        {
            await _residentAssessmentRepository.SaveResidentDetailsActivities(residentDetailsActivities);
        }

        #endregion Details Activities

        #region Details Bathing

        public async Task<ResidentDetailsBathing> GetResidentDetailsBathing(int residentId)
        {
            var detailsBathing = await _residentAssessmentRepository.GetResidentDetailsBathing(residentId);

            ValidateResidentDetailsBathing(detailsBathing);

            return detailsBathing;
        }

        public async Task SaveResidentDetailsBathing(ResidentDetailsBathing residentDetailsBathing)
        {
            await _residentAssessmentRepository.SaveResidentDetailsBathing(residentDetailsBathing);
        }

        #endregion Details Bathing

        #region Details Communication

        public async Task<ResidentDetailsCommunication> GetResidentDetailsCommunication(int residentId)
        {
            var detailsCommunication = await _residentAssessmentRepository.GetResidentDetailsCommunication(residentId);

            ValidateResidentDetailsCommunication(detailsCommunication);

            return detailsCommunication;
        }

        public async Task SaveResidentDetailsCommunication(ResidentDetailsCommunication residentDetailsCommunication)
        {
            await _residentAssessmentRepository.SaveResidentDetailsCommunication(residentDetailsCommunication);
        }

        #endregion Details Communication

        #region Details Dressing

        public async Task<ResidentDetailsDressing> GetResidentDetailsDressing(int residentId)
        {
            var detailsDressing = await _residentAssessmentRepository.GetResidentDetailsDressing(residentId);

            ValidateResidentDetailsDressing(detailsDressing);

            return detailsDressing;
        }

        public async Task SaveResidentDetailsDressing(ResidentDetailsDressing residentDetailsDressing)
        {
            await _residentAssessmentRepository.SaveResidentDetailsDressing(residentDetailsDressing);
        }

        #endregion Details Dressing

        #region Details Eating

        public async Task<ResidentDetailsEating> GetResidentDetailsEating(int residentId)
        {
            var detatilsEating = await _residentAssessmentRepository.GetResidentDetailsEating(residentId);

            ValidateResidentDetailsEating(detatilsEating);

            return detatilsEating;
        }

        public async Task SaveResidentDetailsEating(ResidentDetailsEating residentDetailsEating)
        {
            await _residentAssessmentRepository.SaveResidentDetailsEating(residentDetailsEating);
        }

        #endregion Details Eating

        #region Details Emergency Exiting

        public async Task<ResidentDetailsEmergencyExiting> GetResidentDetailsEmergencyExiting(int residentId)
        {
            var detailsEmergencyExiting = await _residentAssessmentRepository.GetResidentDetailsEmergencyExiting(residentId);

            ValidateResidentDetailsEmergencyExiting(detailsEmergencyExiting);

            return detailsEmergencyExiting;
        }

        public async Task SaveResidentDetailsEmergencyExiting(ResidentDetailsEmergencyExiting residentDetailsEmergencyExiting)
        {
            await _residentAssessmentRepository.SaveResidentDetailsEmergencyExiting(residentDetailsEmergencyExiting);
        }

        #endregion Details Emergency Exiting

        #region Details Grooming

        public async Task<ResidentDetailsGrooming> GetResidentDetailsGrooming(int residentId)
        {
            var detailsGrooming = await _residentAssessmentRepository.GetResidentDetailsGrooming(residentId);

            ValidateResidentDetailsGrooming(detailsGrooming);

            return detailsGrooming;
        }

        public async Task SaveResidentDetailsGrooming(ResidentDetailsGrooming residentDetailsGrooming)
        {
            await _residentAssessmentRepository.SaveResidentDetailsGrooming(residentDetailsGrooming);
        }

        #endregion Details Grooming

        #region Details Mental Status

        public async Task<ResidentDetailsMentalStatus> GetResidentDetailsMentalStatus(int residentId)
        {
            var detailsMentalStatus = await _residentAssessmentRepository.GetResidentDetailsMentalStatus(residentId);

            ValidateResidentDetailsMentalStatus(detailsMentalStatus);

            return detailsMentalStatus;
        }

        public async Task SaveResidentDetailsMentalStatus(ResidentDetailsMentalStatus residentDetailsMentalStatus)
        {
            await _residentAssessmentRepository.SaveResidentDetailsMentalStatus(residentDetailsMentalStatus);
        }

        #endregion Details Mental Status

        #region Details Mobility

        public async Task<ResidentDetailsMobility> GetResidentDetailsMobility(int residentId)
        {
            var detailsMobility = await _residentAssessmentRepository.GetResidentDetailsMobility(residentId);

            ValidateResidentDetailsMobility(detailsMobility);

            return detailsMobility;
        }

        public async Task SaveResidentDetailsMobility(ResidentDetailsMobility residentDetailsMobility)
        {
            await _residentAssessmentRepository.SaveResidentDetailsMobility(residentDetailsMobility);
        }

        #endregion Details Mobility

        #region Details Night Needs

        public async Task<ResidentDetailsNightNeeds> GetResidentDetailsNightNeeds(int residentId)
        {
            var detailsNightNeeds = await _residentAssessmentRepository.GetResidentDetailsNightNeeds(residentId);

            ValidateResidentDetailsNightNeeds(detailsNightNeeds);

            return detailsNightNeeds;
        }

        public async Task SaveResidentDetailsNightNeeds(ResidentDetailsNightNeeds residentDetailsNightNeeds)
        {
            await _residentAssessmentRepository.SaveResidentDetailsNightNeeds(residentDetailsNightNeeds);
        }

        #endregion Details Night Needs

        #region Details Toileting

        public async Task<ResidentDetailsToileting> GetResidentDetailsToileting(int residentId)
        {
            var detailsToileting = await _residentAssessmentRepository.GetResidentDetailsToileting(residentId);

            ValidateResidentDetailsToileting(detailsToileting);

            return detailsToileting;
        }

        public async Task SaveResidentDetailsToileting(ResidentDetailsToileting residentDetailsToileting)
        {
            await _residentAssessmentRepository.SaveResidentDetailsToileting(residentDetailsToileting);
        }

        #endregion Details Toileting

        #region Summary of Information

        public async Task<ResidentSummaryOfInformation> GetResidentSummaryOfInformation(int residentId)
        {
            var summaryOfInformation = new ResidentSummaryOfInformation();

            summaryOfInformation = await _residentAssessmentRepository.GetResidentSummaryOfInformation(residentId);

            return summaryOfInformation;
        }

        public async Task SaveResidentSummaryOfInformation(ResidentSummaryOfInformation residentSummaryOfInformation)
        {
            await _residentAssessmentRepository.SaveResidentSummaryOfInformation(residentSummaryOfInformation);
        }

        #endregion Summary of Information

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Validate resident representatives response from database
        /// </summary>
        /// <param name="residentReprezentatives"></param>
        private void ValidateResidentRepresentatives(ResidentRepresentatives residentReprezentatives)
        {
            if (residentReprezentatives == null)
            {
                throw new ResidentInternalServerErrorException("Representatives - Invalid response from database!");
            }

            if (residentReprezentatives.ResponsibleContact == null)
            {
                throw new ResidentInternalServerErrorException("Responsible contact missing from response!");
            }

            if (residentReprezentatives.SignificantContact == null)
            {
                throw new ResidentInternalServerErrorException("Significant Other contact missing from response!");
            }

            if (residentReprezentatives.EmergencyContact == null)
            {
                throw new ResidentInternalServerErrorException("Emergency contact missing from response!");
            }
        }

        /// <summary>
        /// Validate resident medical representatives response from database
        /// </summary>
        /// <param name="residentMedicalRepresentatives"></param>
        private void ValidateResidentMedicalRepresentatives(ResidentMedicalRepresentatives residentMedicalRepresentatives)
        {
            if (residentMedicalRepresentatives == null)
            {
                throw new ResidentInternalServerErrorException("Medical Representatives - Invalid response from database!");
            }

            if (residentMedicalRepresentatives.PrimaryPhisicianContact == null)
            {
                throw new ResidentInternalServerErrorException("Primary Phisician contact missing from response!");
            }

            if (residentMedicalRepresentatives.SpecialistContact == null)
            {
                throw new ResidentInternalServerErrorException("Specialist contact missing from response!");
            }

            if (residentMedicalRepresentatives.DentistContact == null)
            {
                throw new ResidentInternalServerErrorException("Dentist contact missing from response!");
            }

            if (residentMedicalRepresentatives.HomeHealthContact == null)
            {
                throw new ResidentInternalServerErrorException("Home Health contact missing from response!");
            }
        }

        /// <summary>
        /// Validate resident pharmacy information response from database
        /// </summary>
        /// <param name="residentPharmacyInformation"></param>
        private void ValidateResidentPharmacyInformation(ResidentPharmacyInformation residentPharmacyInformation)
        {
            if (residentPharmacyInformation == null)
            {
                throw new ResidentInternalServerErrorException("Pharmacy Information - Invalid response from database!");
            }

            if (residentPharmacyInformation.PharmacyContact == null)
            {
                throw new ResidentInternalServerErrorException("Pharmacy Information - Missing Pharmacy contact from database!");
            }

            if (residentPharmacyInformation.PharmacyDetails == null)
            {
                throw new ResidentInternalServerErrorException("Pharmacy Information - Missing Pharmacy details from database!");
            }
        }

        /// <summary>
        /// Validate resident nurse response from database
        /// </summary>
        /// <param name="residentNurse"></param>
        private void ValidateResidentNurse(ResidentNurse residentNurse)
        {
            if (residentNurse == null)
            {
                throw new ResidentInternalServerErrorException("Nurse - Invalid response from database!");
            }

            if (residentNurse.NurseContact == null)
            {
                throw new ResidentInternalServerErrorException("Nurse - Missing nurse contact from database!");
            }

            if (residentNurse.NurseDetails == null)
            {
                throw new ResidentInternalServerErrorException("Nurse - Missing nurse details from database!");
            }
        }

        /// <summary>
        /// Validate resident medical equipment response from database
        /// </summary>
        /// <param name="residentMedicalEquipment"></param>
        private void ValidateResidentMedicalEquipment(ResidentMedicalEquipment residentMedicalEquipment)
        {
            if (residentMedicalEquipment == null)
            {
                throw new ResidentInternalServerErrorException("Medical Equipment - Invalid response from database!");
            }

            if (residentMedicalEquipment.MedicalEquipmentDetails == null)
            {
                throw new ResidentInternalServerErrorException("Medical Equipment - Missing medical equipment from database!");
            }

            if (residentMedicalEquipment.MedicalEquipmentSupplierContact == null)
            {
                throw new ResidentInternalServerErrorException("Medical Equipment - Missing medical equipment contact from database!");
            }
        }

        /// <summary>
        /// Validate resident interview response from database
        /// </summary>
        /// <param name="residentInterview"></param>
        private void ValidateResidentInterview(ResidentInterview residentInterview)
        {
            if (residentInterview == null)
            {
                throw new ResidentInternalServerErrorException("Interview - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details activities response from database
        /// </summary>
        /// <param name="residentDetailsActivities"></param>
        private void ValidateResidentDetailsActivities(ResidentDetailsActivities residentDetailsActivities)
        {
            if (residentDetailsActivities == null)
            {
                throw new ResidentInternalServerErrorException("Details Activities - Invalid response from database");
            }
        }

        /// <summary>
        /// Validate resident details bathing response from database
        /// </summary>
        /// <param name="residentDetailsBathing"></param>
        private void ValidateResidentDetailsBathing(ResidentDetailsBathing residentDetailsBathing)
        {
            if (residentDetailsBathing == null)
            {
                throw new ResidentInternalServerErrorException("Details Bathing - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details communication response from database
        /// </summary>
        /// <param name="residentDetailsCommunication"></param>
        private void ValidateResidentDetailsCommunication(ResidentDetailsCommunication residentDetailsCommunication)
        {
            if (residentDetailsCommunication == null)
            {
                throw new ResidentInternalServerErrorException("Details Communication - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details dressing response from database
        /// </summary>
        /// <param name="residentDetailsDressing"></param>
        private void ValidateResidentDetailsDressing(ResidentDetailsDressing residentDetailsDressing)
        {
            if (residentDetailsDressing == null)
            {
                throw new ResidentInternalServerErrorException("Details Dressing - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details eating response from database
        /// </summary>
        /// <param name="residentDetailsEating"></param>
        private void ValidateResidentDetailsEating(ResidentDetailsEating residentDetailsEating)
        {
            if (residentDetailsEating == null)
            {
                throw new ResidentInternalServerErrorException("Details Eating - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details emergency exiting response from database
        /// </summary>
        /// <param name="residentDetailsEmergencyExiting"></param>
        private void ValidateResidentDetailsEmergencyExiting(ResidentDetailsEmergencyExiting residentDetailsEmergencyExiting)
        {
            if (residentDetailsEmergencyExiting == null)
            {
                throw new ResidentInternalServerErrorException("Details Emergency Exiting - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details grooming response from database
        /// </summary>
        /// <param name="residentDetailsGrooming"></param>
        private void ValidateResidentDetailsGrooming(ResidentDetailsGrooming residentDetailsGrooming)
        {
            if (residentDetailsGrooming == null)
            {
                throw new ResidentInternalServerErrorException("Details Grooming - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details mental status response from database
        /// </summary>
        /// <param name="residentDetailsMentalStatus"></param>
        private void ValidateResidentDetailsMentalStatus(ResidentDetailsMentalStatus residentDetailsMentalStatus)
        {
            if (residentDetailsMentalStatus == null)
            {
                throw new ResidentInternalServerErrorException("Details Mental Status - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details mobility status response from database
        /// </summary>
        /// <param name="residentDetailsMobility"></param>
        private void ValidateResidentDetailsMobility(ResidentDetailsMobility residentDetailsMobility)
        {
            if (residentDetailsMobility == null)
            {
                throw new ResidentInternalServerErrorException("Details Mobility - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details night needs response from database
        /// </summary>
        /// <param name="residentDetailsNightNeeds"></param>
        private void ValidateResidentDetailsNightNeeds(ResidentDetailsNightNeeds residentDetailsNightNeeds)
        {
            if (residentDetailsNightNeeds == null)
            {
                throw new ResidentInternalServerErrorException("Details Night Needs - Invalid response from database!");
            }
        }

        /// <summary>
        /// Validate resident details toileting response from database
        /// </summary>
        /// <param name="residentDetailsToileting"></param>
        private void ValidateResidentDetailsToileting(ResidentDetailsToileting residentDetailsToileting)
        {
            if (residentDetailsToileting == null)
            {
                throw new ResidentInternalServerErrorException("Details Night Needs - Invalid response from database!");
            }
        }

        /// <summary>
        /// Create the mapper settings
        /// </summary>
        /// <returns></returns>
        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Assessment, AssessmentEntity>();
                cfg.CreateMap<AssessmentEntity, Assessment>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}
