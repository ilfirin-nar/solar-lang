using System.Collections.Generic;

namespace Solar.Infrastructure.Common.Interfaces.FrontendLayer
{
    public interface IConsoleProgram : IFrontendService
    {
        void Start(IEnumerable<string> args);
    }
}