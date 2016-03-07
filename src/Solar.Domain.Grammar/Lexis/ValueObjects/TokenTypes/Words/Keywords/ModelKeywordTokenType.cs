using Solar.Domain.Grammar.Lexis.Directories;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Keywords
{
    public class ModelKeywordTokenType : KeywordTokenTypeBase
    {
        public ModelKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory) {}
    }
}