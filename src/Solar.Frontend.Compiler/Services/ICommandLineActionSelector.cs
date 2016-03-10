﻿using System;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Interfaces.FrontendLayer;

namespace Solar.Frontend.Compiler.Services
{
    public interface ICommandLineActionSelector : IFrontendService
    {
        Action<CompilerArguments> Select(CompilerArguments arguments);
    }
}