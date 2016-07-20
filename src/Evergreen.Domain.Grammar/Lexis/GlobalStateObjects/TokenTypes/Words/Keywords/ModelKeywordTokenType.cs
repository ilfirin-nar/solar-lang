using Evergreen.Domain.Grammar.Lexis.Directories;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords
{
    public class ModelKeywordTokenType : KeywordTokenTypeBase
    {
        public ModelKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory) {}
    }
}