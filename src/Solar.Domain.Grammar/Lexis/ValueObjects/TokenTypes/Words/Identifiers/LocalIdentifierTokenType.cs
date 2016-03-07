using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Constants;
using Solar.Domain.Grammar.Lexis.Directories;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Identifiers
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