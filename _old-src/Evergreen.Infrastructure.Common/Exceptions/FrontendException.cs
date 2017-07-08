using System;

namespace Evergreen.Infrastructure.Common.Exceptions
{
    public abstract class FrontendException : EvergreenException
    {
        protected FrontendException()
        {
        }

        public FrontendException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}