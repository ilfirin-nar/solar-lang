using System;
using LightInject.Interception;
using Solar.Infrastructure.ErrorHandling.Services;

namespace Solar.Infrastructure.ErrorHandling.Interceptors
{
    public class ErrorHandlingInterceptor : IInterceptor
    {
        private readonly IErrorHandler _errorHandler;

        public ErrorHandlingInterceptor(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public object Invoke(IInvocationInfo invocationInfo)
        {
            try
            {
                return invocationInfo.Proceed();
            }
            catch (Exception exception)
            {
                _errorHandler.Handle(exception);
                return null;
            }
        }
    }
}