using System;
using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Infrastructure.ErrorHandling.Exceptions
{
    public class FatalException : SolarException
    {
        private const string ExceptionMessage = "FATAL!";

        public FatalException(Exception innerException) : base(ExceptionMessage, innerException) {}

        public override string Message => ExceptionMessage;
    }
}