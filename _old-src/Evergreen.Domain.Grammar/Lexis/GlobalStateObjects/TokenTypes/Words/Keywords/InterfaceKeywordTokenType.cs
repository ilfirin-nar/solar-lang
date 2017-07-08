using Evergreen.Domain.Grammar.Lexis.Directories;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords
{
    public class InterfaceKeywordTokenType : KeywordTokenTypeBase
    {
        public InterfaceKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory)
        {}
    }
}