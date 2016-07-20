using System.Collections.Generic;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;

namespace Evergreen.Domain.Grammar.Lexis.Directories
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
            if (!Keywords.ContainsKey(lexeme))
            {
                _keywords.Add(lexeme, keywordTokenType);
            }
            return lexeme;
        }

        public bool IsContains(string lexeme)
        {
            return Keywords.ContainsKey(lexeme);
        }

        private static string GetLexeme(string keywordTokenType)
        {
            return keywordTokenType.Replace("KeywordTokenType", string.Empty).ToLower();
        }
    }
}