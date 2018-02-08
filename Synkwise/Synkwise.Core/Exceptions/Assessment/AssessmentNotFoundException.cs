using System;

namespace Synkwise.Core.Exceptions.Assessment
{
    public class AssessmentNotFoundException : Exception
    {
        public AssessmentNotFoundException() : base()
        {

        }

        public AssessmentNotFoundException(string message) : base(message)
        {

        }

        public AssessmentNotFoundException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
