using System;
using Evergreen.Infrastructure.Common.Exceptions;

namespace Evergreen.Infrastructure.Common.Services.Exceptions
{
    internal class TargetTypeMustHaveConstructorException : InfrastructureException
    {
        private readonly Type _type;

        public TargetTypeMustHaveConstructorException(Type type)
        {
            _type = type;
        }

        public override string Message => $"Target type {_type} must have a constructor";
    }
}