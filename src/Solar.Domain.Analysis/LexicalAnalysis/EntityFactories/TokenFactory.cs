using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Analysis.LexicalAnalysis.Entities;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData;
using Solar.Domain.Analysis.LexicalAnalysis.ValueObjects;

namespace Solar.Domain.Analysis.LexicalAnalysis.EntityFactories
{
    internal class TokenFactory : ITokenFactory
    {
        public Token Produce(TokenRawData rawData)
        {
            return new Token
            {
                Lexem = new Lexem(rawData.Content),
                Type = rawData.TokenType,
                Attributes = new List<TokenAttribute>() // TODO Think about attributes more!
            };
        }

        public IEnumerable<Token> Manufacture(IEnumerable<TokenRawData> rawData)
        {
            return rawData.Select(Produce);
        }
    }
}