using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Identifiers
{
    public class LocalIdentifierTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemesRegularExpressions.WordStartedWithNonCapitalChar;
    }
}