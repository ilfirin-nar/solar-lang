using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Brackets
{
    public class LeftSquareBracketTokenType : BracketTokenType
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.LeftSquareBracket;
    }
}