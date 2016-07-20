using System;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using JetBrains.Annotations;

namespace Evergreen.Infrastructure.ErrorHandling.Services
{
    public interface IErrorHandler : IInfrastructureService
    {
        void Handle([NotNull] Exception exception);
    }
}