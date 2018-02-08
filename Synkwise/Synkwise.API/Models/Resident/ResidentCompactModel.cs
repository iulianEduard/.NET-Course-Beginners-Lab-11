using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.API.Models.Resident
{
    public class ResidentCompactModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Photo { get; set; }
    }
}
