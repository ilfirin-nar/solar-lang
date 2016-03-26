using System.Collections.Generic;
using Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Domain.Grammar.Lexis.Directories
{
    public interface IKeywordsDirectory : IDirectory
    {
        IReadOnlyDictionary<string, IKeywordTokenType> Keywords { get; }

        string Add(IKeywordTokenType keywordTokenType);

        bool IsContains(string lexeme);
    }
}