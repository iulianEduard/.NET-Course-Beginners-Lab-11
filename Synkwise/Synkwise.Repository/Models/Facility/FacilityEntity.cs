using Dapper.Contrib.Extensions;
using System;

namespace Synkwise.Repository.Models.Facility
{
    [Table("dbo.Facility")]
    public class FacilityEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProviderId { get; set; }

        public int ContactId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StatusID { get; set; }
    }
}