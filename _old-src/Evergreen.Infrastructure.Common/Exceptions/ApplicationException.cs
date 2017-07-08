using System;

namespace Evergreen.Infrastructure.Common.Exceptions
{
    public abstract class ApplicationException : EvergreenException
    {
        protected ApplicationException()
        {
        }

        public ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}