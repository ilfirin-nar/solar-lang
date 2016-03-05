using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Constants;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Brackets
{
    public class RightParentheseTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.RightParenthese;
    }
}