using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public abstract class ApplicationException : SolarException
    {
        protected ApplicationException()
        {
        }

        public ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}