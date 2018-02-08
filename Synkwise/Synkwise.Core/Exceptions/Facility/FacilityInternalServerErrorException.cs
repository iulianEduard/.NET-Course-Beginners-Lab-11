using System;

namespace Synkwise.Core.Exceptions.Facility
{
    public class FacilityInternalServerErrorException : Exception
    {
        public FacilityInternalServerErrorException() : base()
        {

        }

        public FacilityInternalServerErrorException(string message) : base(message)
        {

        }

        public FacilityInternalServerErrorException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
