using Evergreen.Domain.Grammar.Exceptions;
using Evergreen.Infrastructure.Common.Exceptions;

namespace Evergreen.Domain.Analysis.Lexical.Exceptions
{
    public class LexicalAnalyzerException : EvergreenException
    {
        private const string ExepthioMessage = "Lexical analysis is failed";

        public LexicalAnalyzerException(GrammarException exception) : base(ExepthioMessage, exception) {}
    }
}