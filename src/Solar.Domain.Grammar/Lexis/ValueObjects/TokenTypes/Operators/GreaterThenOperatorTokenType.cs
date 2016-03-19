using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Operators
{
    public class GreaterThenOperatorTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.GreaterThen;
    }
}