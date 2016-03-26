using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Directories;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers
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