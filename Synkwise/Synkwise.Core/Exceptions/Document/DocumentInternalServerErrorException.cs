using System;

namespace Synkwise.Core.Exceptions.Document
{
    public class DocumentInternalServerErrorException : Exception
    {
        public DocumentInternalServerErrorException() : base()
        {

        }

        public DocumentInternalServerErrorException(string message) : base(message)
        {

        }

        public DocumentInternalServerErrorException(string message, Exception ex) : base (message, ex)
        {

        }
    }
}
