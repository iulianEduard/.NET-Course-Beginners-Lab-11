using Dapper.Contrib.Extensions;

namespace Synkwise.Repository.Models.Contact
{
    [Table("dbo.Contact")]
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        public int ContactTypeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public byte[] Photo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int StateID { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Relationship { get; set; }
    }
}