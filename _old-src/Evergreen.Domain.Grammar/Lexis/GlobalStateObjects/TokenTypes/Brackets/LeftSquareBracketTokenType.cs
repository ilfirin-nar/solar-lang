using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Brackets
{
    public class LeftSquareBracketTokenType : BracketTokenType
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.LeftSquareBracket;
    }
}