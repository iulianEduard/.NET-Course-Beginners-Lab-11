using System;

namespace Synkwise.Core.Exceptions.Facility
{
    public class FacilityBadRequestException : Exception
    {
        public FacilityBadRequestException() : base()
        {

        }

        public FacilityBadRequestException(string message) : base(message)
        {

        }

        public FacilityBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
