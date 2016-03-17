using System;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Interfaces.FrontendLayer;

namespace Solar.Frontend.Compiler.Services
{
    internal interface ICommandLineActionSelector : IFrontendService
    {
        Action<ICompilerArguments> Select(ICompilerArguments arguments);
    }
}