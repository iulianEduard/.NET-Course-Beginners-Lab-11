using Synkwise.API.Models.Contact;
using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class MedicalEquipmentModel
    {
        public MedicalEquipmentDetailsModel MedicalEquipmentDetails { get; set; }

        public ContactModel MedicalEquipmentContact { get; set; }
    }

    public class MedicalEquipmentDetailsModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int? MedicalEquipmentSupplierId { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string EquipmentDelivery { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string EquipmentPaymentResponsible { get; set; }

        public bool InconsistenceSupplies { get; set; }

        public bool PressureReliefDevice { get; set; }

        public bool BedPan { get; set; }

        public bool Cane { get; set; }

        public bool Prosthetics { get; set; }

        public bool Oxygen { get; set; }

        public bool Commode { get; set; }

        public bool QuadCane { get; set; }

        public bool Brace { get; set; }

        public bool OxygenConcentrator { get; set; }

        public bool Urinal { get; set; }

        public bool Wheelchair { get; set; }

        public bool HospitalBed { get; set; }

        public bool Crutches { get; set; }

        public bool Scooter { get; set; }

        public bool BedTray { get; set; }

        public bool CPAP { get; set; }

        public bool Walker { get; set; }

        public bool HoyerLift { get; set; }

        public bool GeriChair { get; set; }

        public bool Nebulizer { get; set; }
    }

}
