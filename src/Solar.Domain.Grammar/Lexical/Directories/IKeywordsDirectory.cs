using System.Collections.Generic;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Domain.Grammar.Lexical.Directories
{
    public interface IKeywordsDirectory : IDirectory
    {
        IReadOnlyDictionary<string, IKeywordTokenType> Keywords { get; }

        string Add(IKeywordTokenType keywordTokenType);

        bool IsContains(string lexeme);
    }
}