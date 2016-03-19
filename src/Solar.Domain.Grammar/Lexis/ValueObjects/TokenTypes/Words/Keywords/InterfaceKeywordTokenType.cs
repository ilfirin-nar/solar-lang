using Solar.Domain.Grammar.Lexis.Directories;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Keywords
{
    public class InterfaceKeywordTokenType : KeywordTokenTypeBase
    {
        public InterfaceKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory)
        {}
    }
}