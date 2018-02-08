﻿using Synkwise.API.Models.Contact;
using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class PharmacyInformationModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string MedicationsDelivery { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string MedicationsPaymentResponsible { get; set; }

        public ContactModel PharamcyContact { get; set; }
    }
}