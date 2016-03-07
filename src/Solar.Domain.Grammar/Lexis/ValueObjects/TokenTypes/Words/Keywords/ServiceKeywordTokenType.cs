using Solar.Domain.Grammar.Lexis.Directories;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Keywords
{
    public class ServiceKeywordTokenType : KeywordTokenTypeBase
    {
        public ServiceKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory) {}
    }
}