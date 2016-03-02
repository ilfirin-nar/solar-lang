using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Analysis.Lexical.Entities;
using Solar.Domain.Analysis.Lexical.EntityFactories.RawData;
using Solar.Domain.Analysis.Lexical.ValueObjects;

namespace Solar.Domain.Analysis.Lexical.EntityFactories
{
    internal class TokenFactory : ITokenFactory
    {
        public Token Produce(TokenRawData rawData)
        {
            return new Token
            {
                Lexem = new Lexem(rawData.Lexeme),
                Type = rawData.TokenType
            };
        }

        public IEnumerable<Token> Manufacture(IEnumerable<TokenRawData> rawData)
        {
            return rawData.Select(Produce);
        }
    }
}