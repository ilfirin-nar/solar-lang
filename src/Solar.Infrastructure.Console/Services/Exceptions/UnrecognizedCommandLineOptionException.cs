using System;
using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Infrastructure.Console.Services.Exceptions
{
    public class UnrecognizedCommandLineOptionException : SolarException
    {
        private readonly string _option;

        public UnrecognizedCommandLineOptionException(string option)
        {
            _option = option;
        }

        public override string Message => $"Unrecognized command line option `{_option}`";
    }
}