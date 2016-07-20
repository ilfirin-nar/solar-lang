using System;
using Evergreen.Infrastructure.ErrorHandling.Services;
using LightInject.Interception;

namespace Evergreen.Infrastructure.ErrorHandling.Interceptors
{
    internal class ErrorHandlingInterceptor : IErrorHandlingInterceptor
    {
        private readonly IErrorHandler _errorHandler;

        public ErrorHandlingInterceptor(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public object Invoke(IInvocationInfo invocationInfo)
        {
            object result = null;
            try
            {
                result = invocationInfo.Proceed();
            }
            catch (Exception exception)
            {
                _errorHandler.Handle(exception);
            }
            return result;
        }
    }
}