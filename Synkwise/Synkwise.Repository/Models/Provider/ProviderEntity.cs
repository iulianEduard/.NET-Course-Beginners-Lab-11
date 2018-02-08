using System;
using Dapper.Contrib.Extensions;

namespace Synkwise.Repository.Models.Provider
{
    [Table("dbo.Provider")]
    public class ProviderEntity
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StatusID { get; set; }
    }
}