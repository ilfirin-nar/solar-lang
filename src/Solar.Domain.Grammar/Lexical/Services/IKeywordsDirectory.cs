using System.Collections.Generic;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexical.Services
{
    public interface IKeywordsDirectory : IDomainService
    {
        IReadOnlyDictionary<string, IKeywordTokenType> Keywords { get; }

        string Add(IKeywordTokenType keywordTokenType);

        bool IsContains(string lexeme);
    }
}