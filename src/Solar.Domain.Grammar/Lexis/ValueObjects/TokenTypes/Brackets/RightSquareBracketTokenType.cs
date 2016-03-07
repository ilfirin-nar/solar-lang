using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Constants;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Brackets
{
    public class RightSquareBracketTokenType : BracketTokenType
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.RightSquareBracket;
    }
}