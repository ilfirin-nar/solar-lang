using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public class FatalException : Exception
    {
        private const string ExceptionMessage = "FATAL!";

        public FatalException(Exception innerException) : base(ExceptionMessage, innerException) {}

        public override string Message => ExceptionMessage;
    }
}