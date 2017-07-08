using Evergreen.Domain.Grammar.Lexis.Directories;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords
{
    public class ServiceKeywordTokenType : KeywordTokenTypeBase
    {
        public ServiceKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory)
        {}
    }
}