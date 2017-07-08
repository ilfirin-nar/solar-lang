using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Brackets
{
    public class RightSquareBracketTokenType : BracketTokenType
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.RightSquareBracket;
    }
}