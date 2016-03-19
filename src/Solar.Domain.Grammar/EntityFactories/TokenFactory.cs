using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.EntityFactories.RawData;

namespace Solar.Domain.Grammar.EntityFactories
{
    internal class TokenFactory : ITokenFactory
    {
        public Token Produce(TokenRawData rawData)
        {
            return new Token(rawData.Lexeme, rawData.TokenType);
        }

        public IEnumerable<Token> Manufacture(IEnumerable<TokenRawData> rawData)
        {
            return rawData.Select(Produce);
        }
    }
}