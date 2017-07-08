using System;

namespace Evergreen.Infrastructure.Common.Exceptions
{
    public abstract class EvergreenException : Exception
    {
        protected EvergreenException()
        {
        }

        public EvergreenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}