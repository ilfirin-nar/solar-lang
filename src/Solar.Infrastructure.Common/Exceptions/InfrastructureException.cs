using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public abstract class InfrastructureException : SolarException
    {
        protected InfrastructureException()
        {
        }

        public InfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}