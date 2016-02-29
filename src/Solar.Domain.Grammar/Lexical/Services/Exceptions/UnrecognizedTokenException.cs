using Solar.Domain.Grammar.Exceptions;

namespace Solar.Domain.Grammar.Lexical.Services.Exceptions
{
    public class UnrecognizedTokenException : GrammarException
    {
        private readonly string _lexeme;

        public UnrecognizedTokenException(string lexeme)
        {
            _lexeme = lexeme;
        }

        public override string Message => $"Token `{_lexeme}` is not recognized";
    }
}