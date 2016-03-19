using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public abstract class DomainException : SolarException
    {
        protected DomainException()
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}