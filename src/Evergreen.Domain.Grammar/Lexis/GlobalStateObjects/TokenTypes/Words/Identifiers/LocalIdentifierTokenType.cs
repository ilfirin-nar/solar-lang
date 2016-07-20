using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Directories;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers
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