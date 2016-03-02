using System;
using Solar.Domain.Grammar.Exceptions;

namespace Solar.Domain.Analysis.Lexical.Exceptions
{
    public class LexicalAnalyzerException : Exception
    {
        private const string ExepthioMessage = "Lexical analysis is failed";

        public LexicalAnalyzerException(GrammarException exception) : base(ExepthioMessage, exception) {}
    }
}