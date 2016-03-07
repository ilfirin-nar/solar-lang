using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Constants;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Identifiers
{
    public class TypeIdentifierTokenType : IdentifierTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.WordStartedWithCapitalChar;
    }
}