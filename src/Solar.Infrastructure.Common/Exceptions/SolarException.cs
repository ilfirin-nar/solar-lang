using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public abstract class SolarException : Exception
    {
        protected SolarException()
        {
        }

        public SolarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}