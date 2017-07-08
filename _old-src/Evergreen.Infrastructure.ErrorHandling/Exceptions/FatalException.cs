using System;
using Evergreen.Infrastructure.Common.Exceptions;

namespace Evergreen.Infrastructure.ErrorHandling.Exceptions
{
    public class FatalException : EvergreenException
    {
        private const string ExceptionMessage = "FATAL!";

        public FatalException(Exception innerException) : base(ExceptionMessage, innerException) {}

        public override string Message => ExceptionMessage;
    }
}