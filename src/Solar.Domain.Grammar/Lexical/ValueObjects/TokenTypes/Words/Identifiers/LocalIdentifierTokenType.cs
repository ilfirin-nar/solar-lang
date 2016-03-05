using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Constants;
using Solar.Domain.Grammar.Lexical.Directories;
using Solar.Domain.Grammar.Lexical.Services;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Identifiers
{
    public class LocalIdentifierTokenType : IdentifierTokenTypeBase
    {
        private readonly IKeywordsDirectory _keywordsDirectory;

        public LocalIdentifierTokenType(IKeywordsDirectory keywordsDirectory)
        {
            _keywordsDirectory = keywordsDirectory;
        }

        protected override Regex CharacteristicRegex => LexemesRegularExpressions.WordStartedWithNonCapitalChar;

        public override bool IsMatch(string lexeme)
        {
            return base.IsMatch(lexeme) && !_keywordsDirectory.IsContains(lexeme);
        }
    }
}