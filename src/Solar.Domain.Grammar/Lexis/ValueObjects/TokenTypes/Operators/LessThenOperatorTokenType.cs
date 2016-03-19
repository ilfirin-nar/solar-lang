using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Operators
{
    public class LessThenOperatorTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.LessThen;
    }
}