using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public class SolarException : Exception
    {
        public SolarException()
        {
        }

        public SolarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}