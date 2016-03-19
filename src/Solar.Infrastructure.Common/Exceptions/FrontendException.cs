﻿using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public abstract class FrontendException : SolarException
    {
        protected FrontendException()
        {
        }

        public FrontendException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}