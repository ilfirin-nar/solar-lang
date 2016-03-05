using Solar.Domain.Grammar.Lexical.Services;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords
{
    public class ServiceKeywordTokenType : KeywordTokenTypeBase
    {
        public ServiceKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory) {}
    }
}