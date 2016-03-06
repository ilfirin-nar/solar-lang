using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Domain.Grammar.ValueObjects;

namespace Solar.Domain.Grammar.EntityFactories
{
    internal class TokenFactory : ITokenFactory
    {
        public Token Produce(TokenRawData rawData)
        {
            var lexem = new Lexeme(rawData.Lexeme);
            var tokenType = rawData.TokenType;
            return new Token(lexem, tokenType);
        }

        public IEnumerable<Token> Manufacture(IEnumerable<TokenRawData> rawData)
        {
            return rawData.Select(Produce);
        }
    }
}