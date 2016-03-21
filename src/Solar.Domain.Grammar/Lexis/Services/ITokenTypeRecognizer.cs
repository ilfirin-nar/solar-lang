﻿using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexis.Services
{
    public interface ITokenTypeRecognizer : IDomainService
    {
        ITokenType Recognize(string lexeme);

        ITokenType ClarifyTokenType(string lexeme, ITokenType currentTokenType);

        bool IsMatch(string lexeme, ITokenType tokenType);
    }
}