using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Contact
{
    public class ContactModel
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "First Name - Maximum length is 50 characters!")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last Name - Maximum length is 50 characters!")]
        public string LastName { get; set; }
        
        public string FullName => $"{FirstName} {LastName}";

        public byte[] Photo { get; set; }

        [StringLength(150, ErrorMessage = "Address - Maximum length is 150 characters!")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Email - Maximum length is 50 characters!")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Phone - Maximum length is 50 characters!")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Fax - Maximum length is 50 characters!")]
        public string Fax { get; set; }

        [StringLength(50, ErrorMessage = "Mobile - Maximum length is 50 characters!")]
        public string Mobile { get; set; }

        public int CityId { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public int ZipcodeId { get; set; }

        [StringLength(50, ErrorMessage = "Zipcode - Maximum length is 50 characters!")]
        public string Zipcode { get; set; }

        public int ContactTypeID { get; set; }

        [StringLength(50, ErrorMessage = "Relationship - Maximum length is 50 characters!")]
        public string Relationship { get; set; }
    }
}