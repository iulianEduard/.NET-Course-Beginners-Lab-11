using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Managers.Contact;
using Synkwise.API.Managers.Resident;
using Synkwise.API.Models;
using Synkwise.API.Models.Resident;
using Synkwise.API.Models.Resident.Assessment;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Provider;
using Synkwise.Repository.Models.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Synkwise.API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api/Resident")]
    public class ResidentController : BaseController
    {
        #region Attributes

        private readonly ResidentManager _residentManager;
        private readonly AssessmentManager _assessmentManager;
        private readonly ContactManager _contactManager;

        #endregion Attributes

        #region Constructor

        public ResidentController(ResidentManager residentManager, ContactManager contactManager, AssessmentManager assessmentManager)
        {
            _residentManager = residentManager;
            _contactManager = contactManager;
            _assessmentManager = assessmentManager;
        }

        #endregion Constructor

        #region Public Methods

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var resident = await _residentManager.Get(id);

            if (resident == null)
            {
                throw new ResidentInternalServerErrorException("Cannot find resident!");
            }

            var residentModel = Mapper.Map<ResidentModel>(resident);
            var response = new ResponseModel
            {
                Message = new { model = residentModel },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpGet("facilities/{facilityID}")]
        public async Task<ActionResult> GetAllByFacility(int facilityID)
        {
            if (facilityID <= 0)
            {
                return NotFound();
            }

            var residentList = await _residentManager.GetByFacility(facilityID);

            if (residentList == null)
            {
                throw new ResidentNotFoundException("Cannot find residents!");
            }

            var residentModel = Mapper.Map<List<ResidentCompactModel>>(residentList);
            var response = new ResponseModel
            {
                Message = new { model = residentModel },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpGet("facilities/{facilityID}/grid")]
        public async Task<ActionResult> GetAllByFacilityForGrid([FromQuery]int facilityID, [FromHeader] int pageNumber, [FromHeader] int pageSize, [FromHeader] string sortColumn, [FromHeader] string sortDirection)
        {
            //to do not used and not validated yet
            if (facilityID <= 0)
            {
                return NotFound();
            }

            var pagination = new GridPagination()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                SortColumn = "ID",
                SortDirection = sortDirection ?? "Asc"
            };
            var residentList = await _residentManager.GetByFacilityForGrid(facilityID, pagination);

            if (residentList == null)
            {
                throw new ResidentInternalServerErrorException("Cannot find residents!");
            }

            var residentModel = Mapper.Map<List<ResidentModel>>(residentList);
            var response = new ResponseModel
            {
                Message = new { model = residentModel },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromBody] ResidentModel residentModel)
        {
            var responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    await _residentManager.Save(residentModel);
                }
                else
                {
                    throw new ResidentBadRequestException(base.GetErrorMessage());
                }
            }
            catch (Exception ex)
            {
                var errorMsg = ex != null ? ex.Message : ex?.InnerException.Message;
                if (string.IsNullOrEmpty(errorMsg))
                    errorMsg = "Unable to save changes. Try again, and if the problem persists see your system administrator.";

                throw new ResidentBadRequestException(errorMsg);
            }

            return Ok(responseModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ResidentModel residentModel)
        {
            var responseModel = new ResponseModel() { Status = HttpStatusCode.OK };
            try
            {
                if (id > 0 && ModelState.IsValid)
                {
                    await _residentManager.Save(residentModel);
                }
                else
                {
                    throw new ResidentBadRequestException(base.GetErrorMessage());
                }
            }
            catch (Exception ex)
            {
                var errorMsg = ex != null ? ex.Message : ex?.InnerException.Message;
                if (string.IsNullOrEmpty(errorMsg))
                    errorMsg = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
                throw new ResidentBadRequestException(errorMsg);
            }

            return Ok(responseModel);
        }

        [HttpPost("activate/{id}")]
        public async Task<ActionResult> Activate(int id)
        {
            var responseModel = new ResponseModel() { Status = HttpStatusCode.OK };
            if (id <= 0)
            {
                throw new ResidentInternalServerErrorException("Can't inactivate resident");
            }

            await _residentManager.Inactivate(id);

            return Ok(responseModel);
        }

        #region Asssessment

        #region Representatives

        [HttpGet("Assessment/{residentId}/Representatives")]
        public async Task<ActionResult> GetRepresentatives(int residentId)
        {
            var reprezentatives = await _assessmentManager.GetResidentRepresentatives(residentId);

            return Ok(reprezentatives);
        }

        [HttpPost("Assessment/{residentId}/Representatives")]
        public async Task<ActionResult> SaveRepresentatives([FromBody] RepresentativesModel representativesModel)
        {
            ValidateSaveResidentRepresentatives(representativesModel);

            if(!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SaveResidentRepresentatives(representativesModel);

            return Ok();
        }

        #endregion Representatives

        #region Medical Representatives

        [HttpGet("Assessment/{residentId}/MedicalRepresentatives")]
        public async Task<ActionResult> GetMedicalRepresentatives(int residentId)
        {
            var medicalRepresentatives = await _assessmentManager.GetMedicalReprezentatives(residentId);

            return Ok(medicalRepresentatives);
        }

        [HttpPost("Assessment/{residentId}/MedicalRepresentatives")]
        public async Task<ActionResult> SaveMedicalRepresentatives([FromBody] MedicalRepresentativesModel medicalRepresentativesModel)
        {
            ValidateSaveResidentMedicalRepresentatives(medicalRepresentativesModel);

            if (!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SaveResidentMedicalRepresentatives(medicalRepresentativesModel);

            return Ok();
        }

        #endregion Medical Representatives

        #region Pharmacy Information

        [HttpGet("Assessment/{residentId}/PharmacyInformation")]
        public async Task<ActionResult> GetPharmacyInformation(int residentId)
        {
            var pharmacyInformation = await _assessmentManager.GetPharmacyInformation(residentId);

            return Ok(pharmacyInformation);
        }

        [HttpPost("Assessment/{residentId}/PharmacyInformation")]
        public async Task<ActionResult> SavePharmacyInformation([FromBody] PharmacyInformationModel pharmacyInformationModel)
        {
            ValidateResidentId(pharmacyInformationModel.ResidentId);

            if (!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SavePharmacyInformation(pharmacyInformationModel);

            return Ok();
        }

        #endregion Pharmacy Information

        #region Nurse

        [HttpGet("Assessment/{residentId}/Nurse")]
        public async Task<ActionResult> GetNurse(int residentId)
        {
            var nurse = await _assessmentManager.GetNurse(residentId);

            return Ok(nurse);
        }

        [HttpPost("Assessment/{residentId}/Nurse")]
        public async Task<ActionResult> SaveNurse([FromBody] NurseModel nurseModel)
        {
            ValidateSaveResidentNurse(nurseModel);

            if (!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SaveNurse(nurseModel);

            return Ok();
        }

        #endregion Nurse

        #region Medical Equipment

        [HttpGet("Assessment/{residentId}/MedicalEquipment")]
        public async Task<ActionResult> GetMedicalEquipment(int residentId)
        {
            var medicalEquipment = await _assessmentManager.GetMedicalEquipment(residentId);

            return Ok(medicalEquipment);
        }

        [HttpPost("Assessment/{residentId}/MedicalEquipment")]
        public async Task<ActionResult> SaveMedicalEquipment([FromBody] MedicalEquipmentModel medicalEquipmentModel)
        {
            ValidateSaveResidentMedicalEquipment(medicalEquipmentModel);

            if (!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SaveMedicalEquipment(medicalEquipmentModel);

            return Ok();
        }

        #endregion Medical Equipment

        #region Interview

        [HttpGet("Assessment/{residentId}/Interview")]
        public async Task<ActionResult> GetInterview(int residentId)
        {
            var interview = await _assessmentManager.GetInterview(residentId);

            return Ok(interview);
        }

        [HttpPost("Assessment/{residentId}/Interview")]
        public async Task<ActionResult> SaveInterview([FromBody] InterviewModel interviewModel)
        {
            ValidateSaveResidentInterview(interviewModel);

            if (!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SaveInterview(interviewModel);

            return Ok();
        }

        #endregion Interview

        #region Resident Assessment

        [HttpGet("Assessment/{residentId}/Details")]
        public async Task<IActionResult> GetResidentAssessmentDetails(int residentId)
        {
            var residentAssessmentDetails = await _assessmentManager.GetResidentAssessmentDetails(residentId);

            return Ok(residentAssessmentDetails);
        }

        [HttpPost("Assessment/{residentId}/Details")]
        public async Task<IActionResult> SaveResidentAssessmentDetails(ResidentAssessmentDetailsModel residentAssessmentDetailsModel)
        {
            ValidateSaveResidentAssessmentDetails(residentAssessmentDetailsModel);

            if (!ModelState.IsValid)
            {
                throw new ResidentBadRequestException(GetErrorMessage());
            }

            await _assessmentManager.SaveResidentAssessmentDetails(residentAssessmentDetailsModel);

            return Ok();
        }

        #endregion Resident Assessment

        #region Summary of Information

        [HttpGet("Assessment/{residentId}/SummaryOfInformation")]
        public async Task<IActionResult> GetResidentSummaryOfInformation(int residentId)
        {
            var summaryOfInformation = await _assessmentManager.GetResidentSummaryOfInformation(residentId);

            return Ok(summaryOfInformation);
        }

        [HttpPost("Assessment/{residentId}/SummaryOfInformation")]
        public async Task<IActionResult> SaveResidentSummaryOfInformation(SummaryOfInformationModel summaryOfInformationModel)
        {
            ValidateSaveResidentSummaryOfInformation(summaryOfInformationModel);

            await _assessmentManager.SaveResidentSummaryOfInformation(summaryOfInformationModel);

            return Ok();
        }

        #endregion Summary of Information

        #endregion Assessment

        #endregion Public Methods

        #region Private Methods

        private void ValidateResidentId(int residentId)
        {
            if (residentId == 0)
            {
                throw new ResidentBadRequestException("Missing resident id!");
            }
        }

        private void ValidateSaveResidentRepresentatives(RepresentativesModel representativesModel)
        {
            if (representativesModel == null)
            {
                throw new ResidentBadRequestException("Representatives - Missing object!");
            }

            if (representativesModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Representatives - Missing resident id!");
            }
        }

        private void ValidateSaveResidentMedicalRepresentatives(MedicalRepresentativesModel medicalRepresentativesModel)
        {
            if (medicalRepresentativesModel == null)
            {
                throw new ResidentBadRequestException("Medical Representatives - Missing object!");
            }

            if (medicalRepresentativesModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Medical Representatives - Missing resident id!");
            }
        }

        private void ValidateSaveResidentNurse(NurseModel nurseModel)
        {
            if (nurseModel == null)
            {
                throw new ResidentBadRequestException("Nurse - Missing object!");
            }

            if (nurseModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Nurse - Missing resident id!");
            }
        }

        private void ValidateSaveResidentMedicalEquipment(MedicalEquipmentModel medicalEquipmentModel)
        {
            if (medicalEquipmentModel == null)
            {
                throw new ResidentBadRequestException("Medical Equipment - Invalid data!");
            }

            if (medicalEquipmentModel.MedicalEquipmentDetails == null)
            {
                throw new ResidentBadRequestException("Medical Equipment - Missing medical equipment data!");
            }

            if (medicalEquipmentModel.MedicalEquipmentContact == null)
            {
                throw new ResidentBadRequestException("Medical Equipment - Missing medical equipment contact data!");
            }
        }

        private void ValidateSaveResidentInterview(InterviewModel interviewModel)
        {
            if (interviewModel == null)
            {
                throw new ResidentBadRequestException("Interview - Invalid data!");
            }

            if (interviewModel.ResidentId == 0)
            {
                throw new ResidentBadRequestException("Interview - Missing resident id!");
            }
        }

        private void ValidateSaveResidentAssessmentDetails(ResidentAssessmentDetailsModel residentAssessmentDetailsModel)
        {
            if(residentAssessmentDetailsModel == null)
            {
                throw new ResidentBadRequestException("Assessment - Invalid data!");
            }
        }

        private void ValidateSaveResidentSummaryOfInformation(SummaryOfInformationModel summaryOfInformationModel)
        {
            if(summaryOfInformationModel == null)
            {
                throw new ResidentBadRequestException("Summary of information - Invalid data!");
            }
        }

        #endregion Private Methods
    }
}
