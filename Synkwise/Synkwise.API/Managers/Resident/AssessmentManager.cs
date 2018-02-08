using AutoMapper;
using Synkwise.API.Models.Contact;
using Synkwise.API.Models.Resident.Assessment;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Provider;
using Synkwise.Core.Models.Resident.Assessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.API.Managers.Resident
{
    public class AssessmentManager
    {
        #region Attributes

        private readonly IResidentAssessmentService _residentAssessmentService;

        #endregion Attributes

        #region Constructor

        public AssessmentManager(IResidentAssessmentService residentAssessmentService)
        {
            _residentAssessmentService = residentAssessmentService;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<ResidentAssessmentModel> GetResidentAssessment(int residentId)
        {
            var residentAssessment = new ResidentAssessmentModel
            {
                Interview = await GetInterview(residentId),
                MedicalEquipment = await GetMedicalEquipment(residentId),
                MedicalRepresentatives = await GetMedicalReprezentatives(residentId),
                Nurse = await GetNurse(residentId),
                PharmacyInformation = await GetPharmacyInformation(residentId),
                Representatives = await GetResidentRepresentatives(residentId),
                ResidentAssessmentDetails = await GetResidentAssessmentDetails(residentId)
            };

            return residentAssessment;
        }

        #region Representatives

        public async Task<RepresentativesModel> GetResidentRepresentatives(int residentId)
        {
            var representativesModel = new RepresentativesModel
            {
                ResidentId = residentId,
                RepresentativesList = new List<ContactModel>()
            };

            var representativesResponse = await _residentAssessmentService.GetResidentRepresentatives(residentId);

            representativesModel.Id = representativesResponse.Id;
            representativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(representativesResponse.ResponsibleContact));
            representativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(representativesResponse.SignificantContact));
            representativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(representativesResponse.EmergencyContact));

            ValidateResidentRepresentatives(representativesModel);

            return representativesModel;
        }

        public async Task SaveResidentRepresentatives(RepresentativesModel representativesModel)
        {
            var representatives = new ResidentRepresentatives
            {
                Id = representativesModel.Id,
                ResidentId = representativesModel.ResidentId,
                ResponsibleContact = new Core.Models.Contact.Contact(),
                SignificantContact = new Core.Models.Contact.Contact(),
                EmergencyContact = new Core.Models.Contact.Contact()
            };

            representatives.ResponsibleContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(representativesModel.RepresentativesList[0]);
            representatives.SignificantContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(representativesModel.RepresentativesList[1]);
            representatives.EmergencyContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(representativesModel.RepresentativesList[2]);

            await _residentAssessmentService.SaveResidentRepresentatives(representatives);
        }

        #endregion Representatives

        #region Medical Representatives

        public async Task<MedicalRepresentativesModel> GetMedicalReprezentatives(int residentId)
        {
            var medicalRepresentativesModel = new MedicalRepresentativesModel
            {
                ResidentId = residentId,
                RepresentativesList = new List<ContactModel>()
            };

            var medicalRepresentativesResponse = await _residentAssessmentService.GetResidentMedicalRepresentatives(residentId);

            medicalRepresentativesModel.Id = medicalRepresentativesResponse.Id;
            medicalRepresentativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(medicalRepresentativesResponse.PrimaryPhisicianContact));
            medicalRepresentativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(medicalRepresentativesResponse.SpecialistContact));
            medicalRepresentativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(medicalRepresentativesResponse.DentistContact));
            medicalRepresentativesModel.RepresentativesList.Add(Mapper.Map<ContactModel>(medicalRepresentativesResponse.HomeHealthContact));

            ValidateResidentMedicalRepresentatives(medicalRepresentativesModel);

            return medicalRepresentativesModel;
        }

        public async Task SaveResidentMedicalRepresentatives(MedicalRepresentativesModel medicalRepresentativesModel)
        {
            var medicalRepresentatives = new ResidentMedicalRepresentatives
            {
                Id = medicalRepresentativesModel.Id,
                ResidentId = medicalRepresentativesModel.ResidentId,
                PrimaryPhisicianContact = new Core.Models.Contact.Contact(),
                SpecialistContact = new Core.Models.Contact.Contact(),
                DentistContact = new Core.Models.Contact.Contact(),
                HomeHealthContact = new Core.Models.Contact.Contact()
            };

            medicalRepresentatives.PrimaryPhisicianContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(medicalRepresentativesModel.RepresentativesList[0]);
            medicalRepresentatives.SpecialistContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(medicalRepresentativesModel.RepresentativesList[1]);
            medicalRepresentatives.DentistContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(medicalRepresentativesModel.RepresentativesList[2]);
            medicalRepresentatives.HomeHealthContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(medicalRepresentativesModel.RepresentativesList[3]);

            await _residentAssessmentService.SaveResidentMedicalRepresentatives(medicalRepresentatives);
        }

        #endregion Medical Representatives

        #region Pharmacy Information

        public async Task<PharmacyInformationModel> GetPharmacyInformation(int residentId)
        {
            var pharmacyInformationModel = new PharmacyInformationModel
            {
                ResidentId = residentId
            };

            var pharmacyInformationResponse = await _residentAssessmentService.GetResidentPharmacyInformation(residentId);

            pharmacyInformationModel.Id = pharmacyInformationResponse.PharmacyDetails.Id;
            pharmacyInformationModel.MedicationsDelivery = pharmacyInformationResponse.PharmacyDetails.MedicationsDelivery;
            pharmacyInformationModel.MedicationsPaymentResponsible = pharmacyInformationResponse.PharmacyDetails.MedicationsPaymentResponsible;
            pharmacyInformationModel.PharamcyContact = Mapper.Map<ContactModel>(pharmacyInformationResponse.PharmacyContact);

            ValidateResidentPharmacyInformation(pharmacyInformationModel);

            return pharmacyInformationModel;
        }

        public async Task SavePharmacyInformation(PharmacyInformationModel pharmacyInformationModel)
        {
            var pharmacyInformation = new ResidentPharmacyInformation
            {
                PharmacyDetails = new ResidentPharmacyInformationDetails(),
                PharmacyContact = new Core.Models.Contact.Contact()
            };

            pharmacyInformation.PharmacyDetails = new ResidentPharmacyInformationDetails
            {
                Id = pharmacyInformationModel.Id,
                ResidentId = pharmacyInformationModel.ResidentId,
                MedicationsDelivery = pharmacyInformationModel.MedicationsDelivery,
                MedicationsPaymentResponsible = pharmacyInformationModel.MedicationsPaymentResponsible
            };

            pharmacyInformation.PharmacyContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(pharmacyInformationModel.PharamcyContact);

            await _residentAssessmentService.SaveResidentPharmacyInformation(pharmacyInformation);
        }

        #endregion Pharmacy Information

        #region Nurse 

        public async Task<NurseModel> GetNurse(int residentId)
        {
            var nurseModel = new NurseModel
            {
                ResidentId = residentId
            };

            var nurseResponse = await _residentAssessmentService.GetResidentNurse(residentId);

            nurseModel.Id = nurseResponse.NurseDetails.Id;
            nurseModel.ConsultationNeeded = nurseResponse.NurseDetails.ConsultationNeeded;
            nurseModel.TasksRequired = nurseResponse.NurseDetails.TaksRequired;
            nurseModel.NurseContact = Mapper.Map<ContactModel>(nurseResponse.NurseContact);

            VadidateResidentNurse(nurseModel);

            return nurseModel;
        }

        public async Task SaveNurse(NurseModel nurseModel)
        {
            var nurse = new ResidentNurse
            {
                NurseDetails = new ResidentNurseDetails(),
                NurseContact = new Core.Models.Contact.Contact()
            };

            nurse.NurseDetails.Id = nurseModel.Id;
            nurse.NurseDetails.ResidentId = nurseModel.ResidentId;
            nurse.NurseDetails.ConsultationNeeded = nurseModel.ConsultationNeeded;
            nurse.NurseDetails.TaksRequired = nurseModel.TasksRequired;
            nurse.NurseContact = Mapper.Map<Synkwise.Core.Models.Contact.Contact>(nurseModel.NurseContact);

            await _residentAssessmentService.SaveResidentNurse(nurse);

        }

        #endregion Nurse

        #region Medical Equipment

        public async Task<MedicalEquipmentModel> GetMedicalEquipment(int residentId)
        {
            var medicalEquipmentModel = new MedicalEquipmentModel
            {
                MedicalEquipmentDetails = new MedicalEquipmentDetailsModel(),
                MedicalEquipmentContact = new ContactModel()
            };

            var medicalEquipmentResponse = await _residentAssessmentService.GetResidentMedicalEquipment(residentId);

            medicalEquipmentModel.MedicalEquipmentDetails = Mapper.Map<MedicalEquipmentDetailsModel>(medicalEquipmentResponse.MedicalEquipmentDetails);
            medicalEquipmentModel.MedicalEquipmentContact = Mapper.Map<ContactModel>(medicalEquipmentResponse.MedicalEquipmentSupplierContact);

            ValidateResidentMedicalEquipment(medicalEquipmentModel);

            return medicalEquipmentModel;
        }

        public async Task SaveMedicalEquipment(MedicalEquipmentModel medicalEquipmentModel)
        {
            var medicalEquipment = new ResidentMedicalEquipment
            {
                MedicalEquipmentDetails = new ResidentMedicalEquipmentDetails(),
                MedicalEquipmentSupplierContact = new Core.Models.Contact.Contact()
            };

            medicalEquipment.MedicalEquipmentDetails = Mapper.Map<ResidentMedicalEquipmentDetails>(medicalEquipmentModel.MedicalEquipmentDetails);
            medicalEquipment.MedicalEquipmentSupplierContact = Mapper.Map<Core.Models.Contact.Contact>(medicalEquipmentModel.MedicalEquipmentContact);

            await _residentAssessmentService.SaveResidentMedicalEquipment(medicalEquipment);
        }

        #endregion Medical Equipment

        #region Interview

        public async Task<InterviewModel> GetInterview(int residentId)
        {
            var interviewModel = new InterviewModel();

            var interview = await _residentAssessmentService.GetResidentInterview(residentId);
            interviewModel = Mapper.Map<InterviewModel>(interview);

            ValidateResiedentInterview(interviewModel);

            return interviewModel;
        }

        public async Task SaveInterview(InterviewModel interviewModel)
        {
            var residentInterview = new ResidentInterview();
            residentInterview = Mapper.Map<ResidentInterview>(interviewModel);

            await _residentAssessmentService.SaveResidentInterview(residentInterview);
        }

        #endregion Interview

        #region Assessment Details

        public async Task<ResidentAssessmentDetailsModel> GetResidentAssessmentDetails(int residentId)
        {
            var asssessmentDetails = new ResidentAssessmentDetailsModel
            {
                DetailsActivities = await GetDetailsActivities(residentId),
                DetailsBathing = await GetDetailsBathing(residentId),
                DetailsCommunication = await GetDetailsCommunication(residentId),
                DetailsDressing = await GetDetailsDressing(residentId),
                DetailsEating = await GetDetailsEating(residentId),
                DetailsEmergencyExiting = await GetDetailsEmergencyExiting(residentId),
                DetailsGrooming = await GetDetailsGrooming(residentId),
                DetailsMentalStatus = await GetDetailsMentalStatus(residentId),
                DetailsMobility = await GetDetailsMobility(residentId),
                DetailsNightNeeds = await GetDetailsNightNeeds(residentId),
                DetailsToileting = await GetDetailsToileting(residentId)
            };

            return asssessmentDetails;
        }

        public async Task SaveResidentAssessmentDetails(ResidentAssessmentDetailsModel residentAssessmentDetailsModel)
        {
            await SaveDetailsActivities(residentAssessmentDetailsModel.DetailsActivities);
            await SaveDetailsBathing(residentAssessmentDetailsModel.DetailsBathing);
            await SaveDetailsCommunication(residentAssessmentDetailsModel.DetailsCommunication);
            await SaveDetailsDressing(residentAssessmentDetailsModel.DetailsDressing);
            await SaveDetailsEating(residentAssessmentDetailsModel.DetailsEating);
            await SaveDetailsEmergencyExiting(residentAssessmentDetailsModel.DetailsEmergencyExiting);
            await SaveDetailsGrooming(residentAssessmentDetailsModel.DetailsGrooming);
            await SaveDetailsMentalStatus(residentAssessmentDetailsModel.DetailsMentalStatus);
            await SaveDetailsMobility(residentAssessmentDetailsModel.DetailsMobility);
            await SaveDetailsNightNeeds(residentAssessmentDetailsModel.DetailsNightNeeds);
            await SaveDetailsToileting(residentAssessmentDetailsModel.DetailsToileting);
        }

        #region Details Activities

        public async Task<DetailsActivitiesModel> GetDetailsActivities(int residentId)
        {
            var detailsActivititiesModel = new DetailsActivitiesModel();

            var detailsActivity = await _residentAssessmentService.GetResidentDetailsActivities(residentId);
            detailsActivititiesModel = Mapper.Map<DetailsActivitiesModel>(detailsActivity);

            ValidateResidentDetailsActivity(detailsActivititiesModel);

            return detailsActivititiesModel;
        }

        public async Task SaveDetailsActivities(DetailsActivitiesModel detailsActivitiesModel)
        {
            var detailsActivities = new ResidentDetailsActivities();
            detailsActivities = Mapper.Map<ResidentDetailsActivities>(detailsActivitiesModel);

            await _residentAssessmentService.SaveResidentDetailsActivities(detailsActivities);
        }

        #endregion Details Activities

        #region Details Bathing

        public async Task<DetailsBathingModel> GetDetailsBathing(int residentId)
        {
            var detailsBathingModel = new DetailsBathingModel();

            var detailsBathing = await _residentAssessmentService.GetResidentDetailsBathing(residentId);
            detailsBathingModel = Mapper.Map<DetailsBathingModel>(detailsBathing);

            ValidateResidentDetailsBathing(detailsBathingModel);

            return detailsBathingModel;
        }

        public async Task SaveDetailsBathing(DetailsBathingModel detailsBathingModel)
        {
            var residentDetailsBathing = new ResidentDetailsBathing();
            residentDetailsBathing = Mapper.Map<ResidentDetailsBathing>(detailsBathingModel);

            await _residentAssessmentService.SaveResidentDetailsBathing(residentDetailsBathing);
        }

        #endregion Details Bathing

        #region Details Communication

        public async Task<DetailsCommunicationModel> GetDetailsCommunication(int residentId)
        {
            var detailsCommunicationModel = new DetailsCommunicationModel();

            var detailsCommunication = await _residentAssessmentService.GetResidentDetailsCommunication(residentId);
            detailsCommunicationModel = Mapper.Map<DetailsCommunicationModel>(detailsCommunication);

            ValidateResidentDetailsCommunication(detailsCommunicationModel);

            return detailsCommunicationModel;
        }

        public async Task SaveDetailsCommunication(DetailsCommunicationModel detailsCommunicationModel)
        {
            var detailsCommunication = new ResidentDetailsCommunication();
            detailsCommunication = Mapper.Map<ResidentDetailsCommunication>(detailsCommunicationModel);

            await _residentAssessmentService.SaveResidentDetailsCommunication(detailsCommunication);
        }

        #endregion Details Communication

        #region Details Dressing

        public async Task<DetailsDressingModel> GetDetailsDressing(int residentId)
        {
            var detailsDressingModel = new DetailsDressingModel();
            var detailsDressing = await _residentAssessmentService.GetResidentDetailsDressing(residentId);

            detailsDressingModel = Mapper.Map<DetailsDressingModel>(detailsDressing);
            ValidateResidentDetailsDressing(detailsDressingModel);

            return detailsDressingModel;
        }

        public async Task SaveDetailsDressing(DetailsDressingModel detailsDressingModel)
        {
            var detailsDressing = new ResidentDetailsDressing();
            detailsDressing = Mapper.Map<ResidentDetailsDressing>(detailsDressingModel);

            await _residentAssessmentService.SaveResidentDetailsDressing(detailsDressing);
        }

        #endregion Details Dressing

        #region Details Eating

        public async Task<DetailsEatingModel> GetDetailsEating(int residentId)
        {
            var detailsEatingModel = new DetailsEatingModel();

            var detailsEating = await _residentAssessmentService.GetResidentDetailsEating(residentId);
            detailsEatingModel = Mapper.Map<DetailsEatingModel>(detailsEating);

            ValidateResidentDetailsEating(detailsEatingModel);

            return detailsEatingModel;
        }

        public async Task SaveDetailsEating(DetailsEatingModel detailsEatingModel)
        {
            var detailsEating = new ResidentDetailsEating();
            detailsEating = Mapper.Map<ResidentDetailsEating>(detailsEatingModel);

            await _residentAssessmentService.SaveResidentDetailsEating(detailsEating);
        }

        #endregion Details Eating

        #region Details Emergency Exiting

        public async Task<DetailsEmergencyExitingModel> GetDetailsEmergencyExiting(int residentId)
        {
            var detailsEmergencyExitingModel = new DetailsEmergencyExitingModel();
            var detailsEmergencyExiting = await _residentAssessmentService.GetResidentDetailsEmergencyExiting(residentId);

            detailsEmergencyExitingModel = Mapper.Map<DetailsEmergencyExitingModel>(detailsEmergencyExiting);

            ValidateResidentDetailsEmergencyExiting(detailsEmergencyExitingModel);

            return detailsEmergencyExitingModel;
        }

        public async Task SaveDetailsEmergencyExiting(DetailsEmergencyExitingModel detailsEmergencyExitingModel)
        {
            var detailsEmergencyExiting = new ResidentDetailsEmergencyExiting();
            detailsEmergencyExiting = Mapper.Map<ResidentDetailsEmergencyExiting>(detailsEmergencyExitingModel);

            await _residentAssessmentService.SaveResidentDetailsEmergencyExiting(detailsEmergencyExiting);
        }

        #endregion Details Emergency Exiting

        #region Details Grooming

        public async Task<DetailsGroomingModel> GetDetailsGrooming(int residentId)
        {
            var detailsGroomingModel = new DetailsGroomingModel();
            var detailsGrooming = await _residentAssessmentService.GetResidentDetailsGrooming(residentId);
            detailsGroomingModel = Mapper.Map<DetailsGroomingModel>(detailsGrooming);

            ValidateResidentDetailsGrooming(detailsGroomingModel);

            return detailsGroomingModel;
        }

        public async Task SaveDetailsGrooming(DetailsGroomingModel detailsGroomingModel)
        {
            var detailsGrooming = new ResidentDetailsGrooming();
            detailsGrooming = Mapper.Map<ResidentDetailsGrooming>(detailsGroomingModel);

            await _residentAssessmentService.SaveResidentDetailsGrooming(detailsGrooming);
        }

        #endregion Details Grooming

        #region Details Mental Status

        public async Task<DetailsMentalStatusModel> GetDetailsMentalStatus(int residentId)
        {
            var detailsMentalStatusModel = new DetailsMentalStatusModel();
            var detailsMentalStatus = await _residentAssessmentService.GetResidentDetailsMentalStatus(residentId);

            detailsMentalStatusModel = Mapper.Map<DetailsMentalStatusModel>(detailsMentalStatus);
            ValidateResidentDetailsMentalStatus(detailsMentalStatusModel);

            return detailsMentalStatusModel;
        }

        public async Task SaveDetailsMentalStatus(DetailsMentalStatusModel detailsMentalStatusModel)
        {
            var detailsMentalStatus = new ResidentDetailsMentalStatus();
            detailsMentalStatus = Mapper.Map<ResidentDetailsMentalStatus>(detailsMentalStatusModel);

            await _residentAssessmentService.SaveResidentDetailsMentalStatus(detailsMentalStatus);
        }

        #endregion Details Mental Status

        #region Details Mobility

        public async Task<DetailsMobilityModel> GetDetailsMobility(int residentId)
        {
            var detailsMobilityModel = new DetailsMobilityModel();
            var detailsMoblity = await _residentAssessmentService.GetResidentDetailsMobility(residentId);

            detailsMobilityModel = Mapper.Map<DetailsMobilityModel>(detailsMoblity);
            ValidateResidentDetailsMoblity(detailsMobilityModel);

            return detailsMobilityModel;
        }

        public async Task SaveDetailsMobility(DetailsMobilityModel detailsMobilityModel)
        {
            var detailsMobility = new ResidentDetailsMobility();
            detailsMobility = Mapper.Map<ResidentDetailsMobility>(detailsMobilityModel);

            await _residentAssessmentService.SaveResidentDetailsMobility(detailsMobility);
        }

        #endregion Details Mobility

        #region Details Night Needs

        public async Task<DetailsNightNeedsModel> GetDetailsNightNeeds(int residentId)
        {
            var detailsNightNeedsModel = new DetailsNightNeedsModel();
            var detailsNightNeeds = await _residentAssessmentService.GetResidentDetailsNightNeeds(residentId);

            detailsNightNeedsModel = Mapper.Map<DetailsNightNeedsModel>(detailsNightNeeds);
            ValidateResidentDetailNightNeeds(detailsNightNeedsModel);

            return detailsNightNeedsModel;
        }

        public async Task SaveDetailsNightNeeds(DetailsNightNeedsModel detailsNightNeedsModel)
        {
            var detailsNightNeeds = new ResidentDetailsNightNeeds();
            detailsNightNeeds = Mapper.Map<ResidentDetailsNightNeeds>(detailsNightNeedsModel);

            await _residentAssessmentService.SaveResidentDetailsNightNeeds(detailsNightNeeds);
        }

        #endregion Details Night Needs

        #region Details Toileting

        public async Task<DetailsToiletingModel> GetDetailsToileting(int residentId)
        {
            var detailsToiletingModel = new DetailsToiletingModel();
            var detailsToileting = await _residentAssessmentService.GetResidentDetailsToileting(residentId);

            detailsToiletingModel = Mapper.Map<DetailsToiletingModel>(detailsToileting);
            ValidateResidentDetailsToileting(detailsToiletingModel);

            return detailsToiletingModel;
        }

        public async Task SaveDetailsToileting(DetailsToiletingModel detailsToiletingModel)
        {
            var detailsToileting = new ResidentDetailsToileting();
            detailsToileting = Mapper.Map<ResidentDetailsToileting>(detailsToiletingModel);

            await _residentAssessmentService.SaveResidentDetailsToileting(detailsToileting);
        }

        #endregion Details Toileting

        #endregion Assessment Details

        #region Summary of Information

        public async Task<SummaryOfInformationModel> GetResidentSummaryOfInformation(int residentId)
        {
            var summaryOfInformationModel = new SummaryOfInformationModel();

            var summaryOfInformation = await _residentAssessmentService.GetResidentSummaryOfInformation(residentId);
            summaryOfInformationModel = Mapper.Map<SummaryOfInformationModel>(summaryOfInformation);

            ValidateResidentSummaryOfInformation(summaryOfInformationModel);

            return summaryOfInformationModel;
        }

        public async Task SaveResidentSummaryOfInformation(SummaryOfInformationModel summaryOfInformationModel)
        {
            var summaryOfInformation = new ResidentSummaryOfInformation();
            summaryOfInformation = Mapper.Map<ResidentSummaryOfInformation>(summaryOfInformationModel);

            await _residentAssessmentService.SaveResidentSummaryOfInformation(summaryOfInformation);
        }

        #endregion Summary of Information

        #endregion Public Methods

        #region Private Methods

        private void ValidateResidentRepresentatives(RepresentativesModel representativesModel)
        {
            if (representativesModel == null)
            {
                throw new ResidentInternalServerErrorException("Representatives - Invalid response from database!");
            }

            if (representativesModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Representatives - Incorrect resident id provided!");
            }

            if (representativesModel.RepresentativesList == null || !representativesModel.RepresentativesList.Any())
            {
                throw new ResidentInternalServerErrorException("Representatives - Invalid response from database!");
            }
        }

        private void ValidateResidentMedicalRepresentatives(MedicalRepresentativesModel medicalRepresentativesModel)
        {
            if (medicalRepresentativesModel == null)
            {
                throw new ResidentInternalServerErrorException("Medical Representatives - Invalid response from database!");
            }

            if (medicalRepresentativesModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Medical Representatives - Incorrect resident id provided!");
            }

            if (medicalRepresentativesModel.RepresentativesList == null || !medicalRepresentativesModel.RepresentativesList.Any())
            {
                throw new ResidentInternalServerErrorException("Medical Representatives - Invalid response from database!");
            }
        }

        private void ValidateResidentPharmacyInformation(PharmacyInformationModel pharmacyInformationModel)
        {
            if (pharmacyInformationModel == null)
            {
                throw new ResidentInternalServerErrorException("Pharmacy Information - Invalid response from database!");
            }

            if (pharmacyInformationModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Pharmacy Information - Incorrect resident id provided!");
            }
        }

        private void VadidateResidentNurse(NurseModel nurseModel)
        {
            if (nurseModel == null)
            {
                throw new ResidentInternalServerErrorException("Nurse - Invalid response from database!");
            }

            if (nurseModel.ResidentId == 0)
            {
                throw new ResidentInternalServerErrorException("Nurse - Incorrect resident id provided!");
            }
        }

        private void ValidateResidentMedicalEquipment(MedicalEquipmentModel medicalEquipmentModel)
        {
            if (medicalEquipmentModel == null)
            {
                throw new ResidentInternalServerErrorException("Medical Equipment - Invalid response from database!");
            }

            if (medicalEquipmentModel.MedicalEquipmentDetails == null)
            {
                throw new ResidentInternalServerErrorException("Medical Equipment - Missing medical equipment response from database!");
            }

            if (medicalEquipmentModel.MedicalEquipmentContact == null)
            {
                throw new ResidentInternalServerErrorException("Medical Equipment - Missing medical equipment contanct response from database!");
            }
        }

        private void ValidateResiedentInterview(InterviewModel interviewModel)
        {
            if (interviewModel == null)
            {
                throw new ResidentInternalServerErrorException("Interview - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsActivity(DetailsActivitiesModel detailsActivitiesModel)
        {
            if (detailsActivitiesModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Activities - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsBathing(DetailsBathingModel detailsBathingModel)
        {
            if (detailsBathingModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Bathing - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsCommunication(DetailsCommunicationModel detailsCommunicationModel)
        {
            if (detailsCommunicationModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Communication - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsDressing(DetailsDressingModel detailsDressingModel)
        {
            if (detailsDressingModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Dressing - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsEating(DetailsEatingModel detailsEatingModel)
        {
            if (detailsEatingModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Eating - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsEmergencyExiting(DetailsEmergencyExitingModel detailsEmergencyExitingModel)
        {
            if (detailsEmergencyExitingModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Emergency Exiting - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsGrooming(DetailsGroomingModel detailsGroomingModel)
        {
            if (detailsGroomingModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Grooming - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsMentalStatus(DetailsMentalStatusModel detailsMentalStatusModel)
        {
            if (detailsMentalStatusModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Mental Status - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsMoblity(DetailsMobilityModel detailsMobilityModel)
        {
            if (detailsMobilityModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Moblity - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailNightNeeds(DetailsNightNeedsModel detailsNightNeedsModel)
        {
            if (detailsNightNeedsModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Night Needs - Invalid response from database!");
            }
        }

        private void ValidateResidentDetailsToileting(DetailsToiletingModel detailsToiletingModel)
        {
            if (detailsToiletingModel == null)
            {
                throw new ResidentInternalServerErrorException("Details Toileting - Invalid response from database!");
            }
        }

        private void ValidateResidentSummaryOfInformation(SummaryOfInformationModel summaryOfInformationModel)
        {
            if(summaryOfInformationModel == null)
            {
                throw new ResidentInternalServerErrorException("Summary of Information - Invalid response from database!");
            }
        }

        #endregion Private Methods
    }
}
