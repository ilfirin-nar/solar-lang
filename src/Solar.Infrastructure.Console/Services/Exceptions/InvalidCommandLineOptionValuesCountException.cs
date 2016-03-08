using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Infrastructure.Console.Services.Exceptions
{
    public class InvalidCommandLineOptionValuesCountException : SolarException
    {
        private readonly string _option;

        public InvalidCommandLineOptionValuesCountException(string option)
        {
            _option = option;
        }

        public override string Message => $"Command line option `{_option}` must have at least one value";
    }
}