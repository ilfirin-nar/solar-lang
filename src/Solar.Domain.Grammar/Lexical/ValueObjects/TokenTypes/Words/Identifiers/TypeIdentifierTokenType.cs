using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Constants;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Identifiers
{
    public class TypeIdentifierTokenType : IdentifierTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.WordStartedWithCapitalChar;
    }
}