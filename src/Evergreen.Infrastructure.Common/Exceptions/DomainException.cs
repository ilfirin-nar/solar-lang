using System;

namespace Evergreen.Infrastructure.Common.Exceptions
{
    public abstract class DomainException : EvergreenException
    {
        protected DomainException()
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}