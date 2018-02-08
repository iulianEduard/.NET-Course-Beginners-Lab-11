namespace Synkwise.Core.Models.Contact
{
    public class Contact
    {
        public int ID { get; set; }

        public int ContactTypeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Photo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        public string ZipCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Relationship { get; set; }
    }
}