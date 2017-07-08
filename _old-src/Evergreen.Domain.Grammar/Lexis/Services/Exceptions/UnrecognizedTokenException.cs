﻿using Evergreen.Domain.Grammar.Exceptions;

namespace Evergreen.Domain.Grammar.Lexis.Services.Exceptions
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