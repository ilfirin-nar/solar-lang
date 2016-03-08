using System;
using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.ErrorHandling.Services
{
    public interface IErrorHandler : IInfrastructureService
    {
        void Handle([NotNull] Exception exception);
    }
}