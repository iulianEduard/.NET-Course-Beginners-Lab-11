using Dapper;
using Dapper.Core.Base;
using Synkwise.Core.Models.Contact;
using Synkwise.Core.Models.Resident.Assessment;
using Synkwise.Repository.Models.Resident;
using Synkwise.Repository.Ports;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class ResidentAssessmentRepository : IResidentAssessmentRepository
    {
        #region Attributes

        private readonly IRepository<object> _residentAssessmentRepository;

        private readonly IRepository<AssessmentEntity> _assessmentRepository;

        #endregion Attributes

        #region Constructor

        public ResidentAssessmentRepository(IRepository<object> residentAssessmentRepository, IRepository<AssessmentEntity> assessmentRepository)
        {
            _residentAssessmentRepository = residentAssessmentRepository;
            _assessmentRepository = assessmentRepository;
        }

        #endregion Constructor

        #region Public Methods

        #region CRUD Assessment

        public async Task<AssessmentEntity> GetAssessementByResidentId(int id, int residentId)
        {
            var assessmentEntity = await _assessmentRepository.GetAsync(id);

            if(assessmentEntity == null)
            {
                return new AssessmentEntity();
            }
            else
            {
                return assessmentEntity;
            }
        }

        public async Task<int> CreateNewAssessmentForResident(AssessmentEntity assessmentEntity)
        {
            await _assessmentRepository.AddAsync(assessmentEntity);

            return assessmentEntity.Id;
        }

        public async Task<int> CloneAssessmentForResident(int originalAssessmentId, int residentId)
        {
            var originalAssessment = await _assessmentRepository.GetAsync(originalAssessmentId);

            var newAssessmentId = await _assessmentRepository.AddAsync(originalAssessment);

            return newAssessmentId;
        }

        public async Task UpdateAssessment(AssessmentEntity assessmentEntity)
        {
            await _assessmentRepository.UpdateAsync(assessmentEntity);
        }

        #endregion CRUD Assessment

        #region Representatives

        public async Task<ResidentRepresentatives> GetResidentReprezentatives(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentID = residentId
            });

            var spResult = await _residentAssessmentRepository.MultipleSetStoredProcedureAsync<ResidentRepresentatives>("ra.usp_GetResidentRepresentatives", RepresentativesResultSet, spParams);

            return spResult;
        }

        public async Task SaveResidentReprezentatives(ResidentRepresentatives residentReprezentatives)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentReprezentatives.ResidentId
                //@Representatives = residentReprezentatives.RezidentReprezentativesList TODO: Convert to DataTable
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentRepresentatives", spParams);
        }

        #endregion Representatives

        #region Medical Representatives

        public async Task<ResidentMedicalRepresentatives> GetResidentMedicalRepresentatives(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentID = residentId
            });

            var spResult = await _residentAssessmentRepository.MultipleSetStoredProcedureAsync<ResidentMedicalRepresentatives>("ra.usp_GetResidentMedicalRepresentatives", MedicalRepresentativesResultSet, spParams);

            return spResult;
        }

        public async Task SaveResidentMedicalRepresentatives(ResidentMedicalRepresentatives residentMedicalRepresentatives)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentMedicalRepresentatives.ResidentId
                //@Representatives = residentReprezentatives.RezidentReprezentativesList TODO: Convert to DataTable
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentMedicalRepresentatives", spParams);
        }

        #endregion Medical Representatives

        #region Pharmacy Information

        public async Task<ResidentPharmacyInformation> GetResidentPharmacyInformation(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.MultipleSetStoredProcedureAsync<ResidentPharmacyInformation>("ra.usp_GetResidentPharmacyInformation", PharmacyInformationResultSet, spParams);

            return spResult;
        }

        public async Task SaveResidentPharmacyInformation(ResidentPharmacyInformation residentPharmacyInformation)
        {
            var spParams = new DynamicParameters(new
            {
                @Id = residentPharmacyInformation.PharmacyDetails.Id,
                @ResidentId = residentPharmacyInformation.PharmacyDetails.ResidentId,
                @MedicationsDelivery = residentPharmacyInformation.PharmacyDetails.MedicationsDelivery,
                @MedicationsPaymentResponsible = residentPharmacyInformation.PharmacyDetails.MedicationsPaymentResponsible
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentPharmacyInformation", spParams);
        }

        #endregion Pharmacy Information

        #region Nurse

        public async Task<ResidentNurse> GetResidentNurse(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.MultipleSetStoredProcedureAsync<ResidentNurse>("ra.usp_GetResidentNurse", NurseResultSet, spParams);

            return spResult;
        }

        public async Task SaveResidentNurse(ResidentNurse residentNurse)
        {
            var spParams = new DynamicParameters(new
            {
                @Id = residentNurse.NurseDetails.Id,
                @ResidentId = residentNurse.NurseDetails.ResidentId,
                @Nurse = residentNurse.NurseContact,
                @ConsultationNeeded = residentNurse.NurseDetails.ConsultationNeeded,
                @TasksRequired = residentNurse.NurseDetails.TaksRequired
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentNurse", spParams);
        }

        #endregion Nurse

        #region Medical Equipment

        public async Task<ResidentMedicalEquipment> GetResidentMedicalEquipment(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.MultipleSetStoredProcedureAsync<ResidentMedicalEquipment>("ra.usp_GetResidentMedicalEquipment", MedicalEquipmentResultSet, spParams);

            return spResult;
        }

        public async Task SaveResidentMedicalEquipment(ResidentMedicalEquipment residentMedicalEquipment)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentMedicalEquipment.MedicalEquipmentDetails.Id,
                @ResidentId = residentMedicalEquipment.MedicalEquipmentDetails.ResidentId,
                @MedicalEquipmentContacts = residentMedicalEquipment.MedicalEquipmentSupplierContact,
                @EquipmentDelivery = residentMedicalEquipment.MedicalEquipmentDetails.EquipmentDelivery,
                @EquipmentPaymentResponsible = residentMedicalEquipment.MedicalEquipmentDetails.EquipmentPaymentResponsible,
                @InconsistenceSupplies = residentMedicalEquipment.MedicalEquipmentDetails.InconsistenceSupplies,
                @PressureReliefDevice = residentMedicalEquipment.MedicalEquipmentDetails.PressureReliefDevice,
                @BedPan = residentMedicalEquipment.MedicalEquipmentDetails.BedPan,
                @Cane = residentMedicalEquipment.MedicalEquipmentDetails.Cane,
                @Prosthetics = residentMedicalEquipment.MedicalEquipmentDetails.Prosthetics,
                @Oxygen = residentMedicalEquipment.MedicalEquipmentDetails.Oxygen,
                @Commode = residentMedicalEquipment.MedicalEquipmentDetails.Commode,
                @QuadCane = residentMedicalEquipment.MedicalEquipmentDetails.QuadCane,
                @Brace = residentMedicalEquipment.MedicalEquipmentDetails.Brace,
                @OxygenConcentrator = residentMedicalEquipment.MedicalEquipmentDetails.OxygenConcentrator,
                @Urinal = residentMedicalEquipment.MedicalEquipmentDetails.Urinal,
                @Wheelchair = residentMedicalEquipment.MedicalEquipmentDetails.Wheelchair,
                @HospitalBed = residentMedicalEquipment.MedicalEquipmentDetails.HospitalBed,
                @Crutches = residentMedicalEquipment.MedicalEquipmentDetails.Crutches,
                @Scooter = residentMedicalEquipment.MedicalEquipmentDetails.Scooter,
                @BedTray = residentMedicalEquipment.MedicalEquipmentDetails.BedTray,
                @CPAP = residentMedicalEquipment.MedicalEquipmentDetails.CPAP,
                @Walker = residentMedicalEquipment.MedicalEquipmentDetails.Walker,
                @HoyerLift = residentMedicalEquipment.MedicalEquipmentDetails.HoyerLift,
                @GeriChair = residentMedicalEquipment.MedicalEquipmentDetails.GeriChair,
                @Nebulizer = residentMedicalEquipment.MedicalEquipmentDetails.Nebulizer
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentMedicalEquipment", spParams);
        }

        #endregion Medical Equipment

        #region Interview

        public async Task<ResidentInterview> GetResidentInterview(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentInterview>("ra.usp_GetResidentInterview", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentInterview(ResidentInterview residentInterview)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentInterview.Id,
                @ResidentID = residentInterview.ResidentId,
                @CaseManager = residentInterview.CaseManager,
                @CurentTherapist = residentInterview.CurentTherapist,
                @CurrentPhysician = residentInterview.CurrentPhysician,
                @CurrentPharmacist = residentInterview.CurrentPharmacist,
                @HospitalStaff = residentInterview.HospitalStaff,
                @MentalHealthProfessional = residentInterview.MentalHealthProfessional,
                @PriorCareProvider = residentInterview.PriorCareProvider,
                @Resident = residentInterview.Resident,
                @ResidentsFamily = residentInterview.ResidentsFamily,
                @ResidentsGuardian = residentInterview.ResidentsGuardian
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentInterview", spParams);
        }

        #endregion Interview

        #region Details Activities

        public async Task<ResidentDetailsActivities> GetResidentDetailsActivities(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsActivities>("ra.usp_GetResidentDetailsActivities", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsActivities(ResidentDetailsActivities residentDetailsActivities)
        {
            var spParams = new DynamicParameters(new
            {
                @Id = residentDetailsActivities.Id,
                @ResidentId = residentDetailsActivities.ResidentId,
                @Details = residentDetailsActivities.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsActivities", spParams);
        }

        #endregion Details Activities

        #region Details Bathing

        public async Task<ResidentDetailsBathing> GetResidentDetailsBathing(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsBathing>("ra.usp_GetResidentDetailsBathing", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsBathing(ResidentDetailsBathing residentDetailsBathing)
        {
            var spParams = new DynamicParameters(new
            {
                @Id = residentDetailsBathing.Id,
                @ResidentId = residentDetailsBathing.ResidentId,
                @NeedsAssitance = residentDetailsBathing.NeedAssitance,
                @SpecialEquipment = residentDetailsBathing.SpecialEquipment,
                @Details = residentDetailsBathing.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsBathing>("ra.usp_SaveResidentDetailsBathing", spParams);
        }

        #endregion Details Bathing

        #region Details Communication

        public async Task<ResidentDetailsCommunication> GetResidentDetailsCommunication(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsCommunication>("ra.usp_GetResidentDetailsCommunication", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsCommunication(ResidentDetailsCommunication residentDetailsCommunication)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsCommunication.Id,
                @ResidentID = residentDetailsCommunication.ResidentId,
                @NeedsAssistance = residentDetailsCommunication.NeedsAssistance,
                @AbleToSee = residentDetailsCommunication.AbleToSee,
                @AwareOfNeeds = residentDetailsCommunication.AwareOfNeeds,
                @AbleToHear = residentDetailsCommunication.AbleToHear,
                @SpecialEquipment = residentDetailsCommunication.SpecialEquipment,
                @AbleToSpeak = residentDetailsCommunication.AbleToSpeak,
                @HearingAid = residentDetailsCommunication.HearingAid,
                @SpeechImpediment = residentDetailsCommunication.SpeechImpediment,
                @SignLanguage = residentDetailsCommunication.SignLanguage,
                @Gestures = residentDetailsCommunication.Gestures,
                @ForeignLanguage = residentDetailsCommunication.ForeignLanguage,
                @Details = residentDetailsCommunication.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsCommunication", spParams);
        }

        #endregion Details Communication

        #region Details Dressing

        public async Task<ResidentDetailsDressing> GetResidentDetailsDressing(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsDressing>("ra.usp_GetResidentDetailsDressing", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsDressing(ResidentDetailsDressing residentDetailsDressing)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsDressing.Id,
                @ResidentID = residentDetailsDressing.ResidentId,
                @NeedsAssistance = residentDetailsDressing.NeedsAssisstance,
                @SpecialEquipment = residentDetailsDressing.SpecialEquipment,
                @ChoosesOwnClothes = residentDetailsDressing.ChoosesOwnClothes,
                @Details = residentDetailsDressing.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsDressing", spParams);
        }

        #endregion Details Dressing

        #region Details Eating

        public async Task<ResidentDetailsEating> GetResidentDetailsEating(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsEating>("ra.usp_GetResidentDetailsEating", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsEating(ResidentDetailsEating residentDetailsEating)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsEating.Id,
                @ResidentID = residentDetailsEating.ResidentId,
                @NeedsAssistance = residentDetailsEating.NeedsAssistance,
                @DifficultySwallowing = residentDetailsEating.DifficultySwallowing,
                @SpecialPreparations = residentDetailsEating.SpecialPreparations,
                @AwareOfNeeds = residentDetailsEating.AwareOfNeeds,
                @ChokingRisk = residentDetailsEating.ChokingRisk,
                @SpecialDiet = residentDetailsEating.SpecialDiet,
                @FoodAllergies = residentDetailsEating.FoodAllergies,
                @SpecialEquipment = residentDetailsEating.SpecialEquipment,
                @SoftSolids = residentDetailsEating.SoftSolids,
                @ThickenedFluids = residentDetailsEating.ThickenedFluids,
                @PureedFoods = residentDetailsEating.PureedFoods,
                @LimitedFuildIntake = residentDetailsEating.LimitedFuildIntake,
                @Details = residentDetailsEating.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsEating", spParams);
        }

        #endregion Details Eating

        #region Details Emergency Exiting

        public async Task<ResidentDetailsEmergencyExiting> GetResidentDetailsEmergencyExiting(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsEmergencyExiting>("ra.usp_GetResidentDetailsEmergencyExiting", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsEmergencyExiting(ResidentDetailsEmergencyExiting residentDetailsEmergencyExiting)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsEmergencyExiting.Id,
                @ResidentID = residentDetailsEmergencyExiting.ResidentId,
                @NeedsAssistance = residentDetailsEmergencyExiting.NeedsAssistance,
                @SpecialEquipment = residentDetailsEmergencyExiting.SpecialEquipment,
                @AwareOfNeeds = residentDetailsEmergencyExiting.AwareOfNeeds,
                @StrobeLight = residentDetailsEmergencyExiting.StrobeLight,
                @VibratingDevice = residentDetailsEmergencyExiting.VibratingDevice,
                @Details = residentDetailsEmergencyExiting.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsEmergencyExiting", spParams);
        }

        #endregion Details Emergency Exiting

        #region Details Grooming

        public async Task<ResidentDetailsGrooming> GetResidentDetailsGrooming(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsGrooming>("ra.usp_GetResidentDetailsGrooming", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsGrooming(ResidentDetailsGrooming residentDetailsGrooming)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsGrooming.Id,
                @ResidentID = residentDetailsGrooming.ResidentId,
                @NeedsAssistance = residentDetailsGrooming.NeedsAssistance,
                @SkinCondition = residentDetailsGrooming.SkinCondition,
                @AwareOfNeeds = residentDetailsGrooming.AwareOfNeeds,
                @SpecialEquipment = residentDetailsGrooming.SpecialEquipment,
                @Details = residentDetailsGrooming.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsGrooming", spParams);
        }

        #endregion Details Grooming

        #region Details Mental Status

        public async Task<ResidentDetailsMentalStatus> GetResidentDetailsMentalStatus(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsMentalStatus>("ra.usp_GetResidentDetailsMentalStatus", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsMentalStatus(ResidentDetailsMentalStatus residentDetailsMentalStatus)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsMentalStatus.Id,
                @ResidentID = residentDetailsMentalStatus.ResidentId,
                @Oriented = residentDetailsMentalStatus.Oriented,
                @AwareOfNeeds = residentDetailsMentalStatus.AwareOfNeeds,
                @HistoryOfMentalIllness = residentDetailsMentalStatus.HistoryOfMentalIllness,
                @Wanders = residentDetailsMentalStatus.Wanders,
                @MemoryLapses = residentDetailsMentalStatus.MemoryLapses,
                @CooperativeWithCare = residentDetailsMentalStatus.CooperativeWithCare,
                @DangerToSelfOrOthers = residentDetailsMentalStatus.DangerToSelfOrOthers,
                @Behaviours = residentDetailsMentalStatus.Behaviours,
                @Details = residentDetailsMentalStatus.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsMentalStatus>("ra.usp_SaveResidentDetailsMentalStatus", spParams);
        }

        #endregion Details Mental Status 

        #region Details Mobility

        public async Task<ResidentDetailsMobility> GetResidentDetailsMobility(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsMobility>("ra.usp_GetResidentDetailsMobility", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsMobility(ResidentDetailsMobility residentDetailsMobility)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsMobility.Id,
                @ResidentID = residentDetailsMobility.ResidentId,
                @NeedsAssistanceInWalking = residentDetailsMobility.NeedsAssistanceInWalking,
                @NeedsAssistanceWheelChair = residentDetailsMobility.NeedsAssistanceWheelChair,
                @TiresEasely = residentDetailsMobility.TiresEasely,
                @SpecialEquipment = residentDetailsMobility.SpecialEquipment,
                @BedBound = residentDetailsMobility.BedBound,
                @NeedsAssistanceInTransferring = residentDetailsMobility.NeedsAssistanceInTransferring,
                @AwareOfNeeds = residentDetailsMobility.AwareOfNeeds,
                @Details = residentDetailsMobility.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsMobility", spParams);
        }

        #endregion Details Mobility

        #region Details Night Needs

        public async Task<ResidentDetailsNightNeeds> GetResidentDetailsNightNeeds(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsNightNeeds>("ra.usp_GetResidentDetailsNightNeeds", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsNightNeeds(ResidentDetailsNightNeeds residentDetailsNightNeeds)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsNightNeeds.Id,
                @ResidentID = residentDetailsNightNeeds.ResidentId,
                @NeedsAssistance = residentDetailsNightNeeds.NeedsAssistance,
                @DifficultySleeping = residentDetailsNightNeeds.DifficultySleeping,
                @AwareOfNeeds = residentDetailsNightNeeds.AwareOfNeeds,
                @SpecialEquipment = residentDetailsNightNeeds.SpecialEquipment,
                @Details = residentDetailsNightNeeds.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsNightNeeds", spParams);
        }

        #endregion Details Night Needs

        #region Details Toileting

        public async Task<ResidentDetailsToileting> GetResidentDetailsToileting(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentDetailsToileting>("ra.usp_GetResidentDetailsToileting", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentDetailsToileting(ResidentDetailsToileting residentDetailsToileting)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentDetailsToileting.Id,
                @ResidentID = residentDetailsToileting.ResidentId,
                @NeedsAssistance = residentDetailsToileting.NeedsAssistance,
                @ToiletingPlan = residentDetailsToileting.ToiletingPlan,
                @Catherer = residentDetailsToileting.Catherer,
                @Ostomy = residentDetailsToileting.Ostomy,
                @IncontinentBladder = residentDetailsToileting.IncontinentBladder,
                @IncontinentBowel = residentDetailsToileting.IncontinentBowel,
                @IncontinentSupplies = residentDetailsToileting.IncontinentSupplies,
                @DoesResidentAgreeToWear = residentDetailsToileting.DoesResidentAgreeToWear,
                @WillResidentLeaveOn = residentDetailsToileting.WillResidentLeaveOn,
                @Details = residentDetailsToileting.Details
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentDetailsToileting", spParams);
        }

        #endregion Details Toileting

        #region Summary of Information

        public async Task<ResidentSummaryOfInformation> GetResidentSummaryOfInformation(int residentId)
        {
            var spParams = new DynamicParameters(new
            {
                @ResidentId = residentId
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<ResidentSummaryOfInformation>("ra.usp_GetResidentSummaryOfInformation ", spParams);

            return spResult.FirstOrDefault();
        }

        public async Task SaveResidentSummaryOfInformation(ResidentSummaryOfInformation residentSummaryOfInformation)
        {
            var spParams = new DynamicParameters(new
            {
                @ID = residentSummaryOfInformation.Id,
                @ResidentID = residentSummaryOfInformation.ResidentId,
                @IndependentNumberActivties = residentSummaryOfInformation.IndependentNumberActivties,
                @AssistanceNumberActivities = residentSummaryOfInformation.AssistanceNumberActivities,
                @FullAssistanceNumberActivities = residentSummaryOfInformation.FullAssistanceNumberActivities,
                @ResidentNeedClassificationHome = residentSummaryOfInformation.ResidentNeedClassificationHome,
                @LicenseeCaregiversResidentNeeds = residentSummaryOfInformation.LicenseeCaregiversResidentNeeds,
                @ResidentNeedWithoutCompromisingResidents = residentSummaryOfInformation.ResidentNeedWithoutCompromisingResidents,
                @ResidentCanBeEvacuatedIn3Minutes = residentSummaryOfInformation.ResidentCanBeEvacuatedIn3Minutes,
                @CopyOfPhysicianOrders = residentSummaryOfInformation.CopyOfPhysicianOrders,
                @ArragementsforRNConsulting = residentSummaryOfInformation.ArragementsforRNConsulting,
                @MentalStatusAndBehaviours = residentSummaryOfInformation.MentalStatusAndBehaviours,
                @BathingAndPersonalHygiene = residentSummaryOfInformation.BathingAndPersonalHygiene,
                @Dressing = residentSummaryOfInformation.Dressing,
                @Toileting = residentSummaryOfInformation.Toileting,
                @Mobility = residentSummaryOfInformation.Mobility,
                @Eating = residentSummaryOfInformation.Eating,
                @Communication = residentSummaryOfInformation.Communication,
                @NightNeeds = residentSummaryOfInformation.NightNeeds,
                @EmergencyExisting = residentSummaryOfInformation.EmergencyExisting,
                @SignatureOfLicensee = residentSummaryOfInformation.SignatureOfLicensee,
                @SignDate = residentSummaryOfInformation.SignDate,
                @CreatedDate = residentSummaryOfInformation.CreatedDate,
                @AssessmentID = residentSummaryOfInformation.AssessmentID
            });

            var spResult = await _residentAssessmentRepository.SingleSetStoredProcedureAsync<int>("ra.usp_SaveResidentSummaryOfInformation ", spParams);
        }

        #endregion Summary of Information

        #endregion Public Methods

        #region Private Methods

        private Func<dynamic, ResidentRepresentatives> RepresentativesResultSet { get; } = gridData =>
        {
            var resultSet = new ResidentRepresentatives()
            {
                ResponsibleContact = gridData.ReadFirst<Contact>(),
                SignificantContact = gridData.ReadFirst<Contact>(),
                EmergencyContact = gridData.ReadFirst<Contact>(),
                Id = gridData.ReadFirst<int>()
            };

            return resultSet;
        };

        private Func<dynamic, ResidentMedicalRepresentatives> MedicalRepresentativesResultSet { get; } = gridData =>
        {
            var resultSet = new ResidentMedicalRepresentatives()
            {
                PrimaryPhisicianContact = gridData.ReadFirst<Contact>(),
                SpecialistContact = gridData.ReadFirst<Contact>(),
                DentistContact = gridData.ReadFirst<Contact>(),
                HomeHealthContact = gridData.ReadFirst<Contact>(),
                Id = gridData.ReadFirst<int>()
            };

            return resultSet;
        };

        private Func<dynamic, ResidentPharmacyInformation> PharmacyInformationResultSet { get; } = gridData =>
        {
            var resultSet = new ResidentPharmacyInformation()
            {
                PharmacyDetails = gridData.ReadFirst<ResidentPharmacyInformationDetails>(),
                PharmacyContact = gridData.ReadFirst<Contact>()
            };

            return resultSet;
        };

        private Func<dynamic, ResidentNurse> NurseResultSet { get; } = gridData =>
        {
            var resultSet = new ResidentNurse()
            {
                NurseDetails = gridData.ReadFirst<ResidentNurseDetails>(),
                NurseContact = gridData.ReadFirst<Contact>()
            };

            return resultSet;
        };

        private Func<dynamic, ResidentMedicalEquipment> MedicalEquipmentResultSet { get; } = gridData =>
        {
            var resultSet = new ResidentMedicalEquipment()
            {
                MedicalEquipmentDetails = gridData.ReadFirst<ResidentMedicalEquipmentDetails>(),
                MedicalEquipmentSupplierContact = gridData.ReadFirst<Contact>()
            };

            return resultSet;
        };

        #endregion Private Methods
    }
}
