using Solar.Domain.Grammar.Lexical.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData
{
    internal class TokenRawData : IEntityRawData
    {
        public TokenRawData(string lexeme, ITokenType tokenType)
        {
            Lexeme = lexeme;
            TokenType = tokenType;
        }

        public string Lexeme { get; set; }

        public ITokenType TokenType { get; set; }
    }
}