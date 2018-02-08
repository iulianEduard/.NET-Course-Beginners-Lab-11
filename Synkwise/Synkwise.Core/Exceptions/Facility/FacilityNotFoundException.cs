using System;

namespace Synkwise.Core.Exceptions.Facility
{
    public class FacilityNotFoundException: Exception
    {
        public FacilityNotFoundException() : base()
        {

        }

        public FacilityNotFoundException(string message) : base(message)
        {

        }

        public FacilityNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
