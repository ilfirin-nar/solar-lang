using Evergreen.Infrastructure.Common.Exceptions;

namespace Evergreen.Infrastructure.Console.Arguments.Services.Exceptions
{
    public class UnrecognizedCommandLineOptionException : EvergreenException
    {
        private readonly string _option;

        public UnrecognizedCommandLineOptionException(string option)
        {
            _option = option;
        }

        public override string Message => $"Unrecognized command line option `{_option}`";
    }
}