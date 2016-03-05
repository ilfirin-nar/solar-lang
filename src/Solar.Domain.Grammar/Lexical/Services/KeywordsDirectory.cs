using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords;

namespace Solar.Domain.Grammar.Lexical.Services
{
    internal class KeywordsDirectory : IKeywordsDirectory
    {
        private readonly Dictionary<string, IKeywordTokenType> _keywords;

        public KeywordsDirectory()
        {
            _keywords = new Dictionary<string, IKeywordTokenType>();
        }

        public IReadOnlyDictionary<string, IKeywordTokenType> Keywords => _keywords;

        public string Add(IKeywordTokenType keywordTokenType)
        {
            var tokenTypeName = keywordTokenType.GetType().Name;
            var lexeme = GetLexeme(tokenTypeName);
            _keywords.Add(lexeme, keywordTokenType);
            return lexeme;
        }

        public bool IsContains(string lexeme)
        {
            return Keywords.Keys.Contains(lexeme);
        }

        private static string GetLexeme(string keywordTokenType)
        {
            return keywordTokenType.Replace("KeywordTokenType", string.Empty).ToLower();
        }
    }
}