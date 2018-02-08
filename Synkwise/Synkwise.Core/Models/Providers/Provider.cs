using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Providers
{
    public class Provider
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public int StatusID { get; set; }
    }
}
