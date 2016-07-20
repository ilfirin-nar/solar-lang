using Evergreen.Infrastructure.Common.Exceptions;

namespace Evergreen.Infrastructure.Console.Arguments.Services.Exceptions
{
    public class InvalidCommandLineOptionValuesCountException : EvergreenException
    {
        private readonly string _option;
        private readonly int _count;
        private readonly bool _allowMultiple;

        public InvalidCommandLineOptionValuesCountException(string option, int count, bool allowMultiple)
        {
            _option = option;
            _count = count;
            _allowMultiple = allowMultiple;
        }

        public override string Message
        {
            get
            {
                var atLeast = _allowMultiple ? " at least " : " ";
                return $"Command line option `{_option}` have {_count} values but must have{atLeast}one value";
            }
        }
    }
}