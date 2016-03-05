using System.Linq;
using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Constants;
using Solar.Domain.Grammar.Lexical.Services;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords
{
    public abstract class KeywordTokenTypeBase : WordTokenTypeBase, IKeywordTokenType
    {
        protected KeywordTokenTypeBase(IKeywordsDirectory keywordsDirectory)
        {
            Lexeme = keywordsDirectory.Add(this);
            TryLexemeRegex = new Regex($"^{Lexeme}$");
        }

        public string Lexeme { get; }

        protected override Regex CharacteristicRegex => LexemesRegularExpressions.LowerCaseWord;

        private Regex TryLexemeRegex { get; }

        public override bool IsMatch(string lexeme)
        {
            return base.IsMatch(lexeme) && TryLexemeRegex.IsMatch(lexeme);
        }
    }
}