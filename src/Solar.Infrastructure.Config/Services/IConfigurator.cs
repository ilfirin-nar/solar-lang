﻿using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Config.Services
{
    public interface IConfigurator : IInfrastructureService
    {
        void Configure([NotNull] string configPath);
    }
}