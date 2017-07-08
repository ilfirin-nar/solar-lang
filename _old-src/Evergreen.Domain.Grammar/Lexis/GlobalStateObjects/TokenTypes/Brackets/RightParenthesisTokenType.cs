using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Brackets
{
    public class RightParenthesisTokenType : BracketTokenType
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.RightParenthesis;
    }
}