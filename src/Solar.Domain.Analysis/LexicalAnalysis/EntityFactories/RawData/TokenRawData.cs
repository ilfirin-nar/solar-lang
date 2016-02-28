using Solar.Domain.Grammar.Lexical;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData
{
    internal class TokenRawData : IEntityRawData
    {
        public TokenRawData(string content, ITokenType tokenType)
        {
            Content = content;
            TokenType = tokenType;
        }

        public string Content { get; set; }

        public ITokenType TokenType { get; set; }
    }
}