using System;

namespace Synkwise.Core.Exceptions.Assessment
{
    public class AssessmentInternalServerErrorException : Exception
    {
        public AssessmentInternalServerErrorException() : base()
        {

        }

        public AssessmentInternalServerErrorException(string message) : base(message)
        {

        }

        public AssessmentInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
