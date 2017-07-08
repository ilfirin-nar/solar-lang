using System.Collections.Generic;

namespace Evergreen.Infrastructure.Common.Interfaces.FrontendLayer
{
    public interface IConsoleProgram : IFrontendService
    {
        void Start(IEnumerable<string> args);
    }
}