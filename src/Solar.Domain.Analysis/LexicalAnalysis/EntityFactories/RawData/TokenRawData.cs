using Solar.Domain.Grammar.Enums;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData
{
    internal class TokenRawData : IEntityRawData
    {
        public TokenRawData(string content, TokenType tokenType)
        {
            Content = content;
            TokenType = tokenType;
        }

        public string Content { get; set; }

        public TokenType TokenType { get; set; }
    }
}