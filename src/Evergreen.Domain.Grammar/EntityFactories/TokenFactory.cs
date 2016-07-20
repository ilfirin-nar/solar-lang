using System.Collections.Generic;
using System.Linq;
using Evergreen.Domain.Grammar.Entities;
using Evergreen.Domain.Grammar.EntityFactories.RawData;

namespace Evergreen.Domain.Grammar.EntityFactories
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