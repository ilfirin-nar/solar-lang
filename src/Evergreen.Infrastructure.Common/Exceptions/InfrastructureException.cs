using System;

namespace Evergreen.Infrastructure.Common.Exceptions
{
    public abstract class InfrastructureException : EvergreenException
    {
        protected InfrastructureException()
        {
        }

        public InfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}