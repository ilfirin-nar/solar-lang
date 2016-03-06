using Solar.Domain.Grammar.Exceptions;
using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Domain.Analysis.Lexical.Exceptions
{
    public class LexicalAnalyzerException : SolarException
    {
        private const string ExepthioMessage = "Lexical analysis is failed";

        public LexicalAnalyzerException(GrammarException exception) : base(ExepthioMessage, exception) {}
    }
}