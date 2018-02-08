using System;

namespace Synkwise.Core.Exceptions.Assessment
{
    public class AssessmentBadRequestException : Exception
    {
        public AssessmentBadRequestException() : base()
        {

        }

        public AssessmentBadRequestException(string message) : base(message)
        {

        }

        public AssessmentBadRequestException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
