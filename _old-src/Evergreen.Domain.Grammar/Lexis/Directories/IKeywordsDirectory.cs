using System.Collections.Generic;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;
using Evergreen.Infrastructure.Common.Interfaces;

namespace Evergreen.Domain.Grammar.Lexis.Directories
{
    public interface IKeywordsDirectory : IDirectory
    {
        IReadOnlyDictionary<string, IKeywordTokenType> Keywords { get; }

        string Add(IKeywordTokenType keywordTokenType);

        bool IsContains(string lexeme);
    }
}