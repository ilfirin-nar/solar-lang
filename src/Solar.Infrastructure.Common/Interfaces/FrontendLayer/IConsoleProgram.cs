namespace Solar.Infrastructure.Common.Interfaces.FrontendLayer
{
    public interface IConsoleProgram : IFrontendService
    {
        void Start(string[] args);
    }
}