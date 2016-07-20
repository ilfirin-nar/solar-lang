using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators
{
    public class AssigmentOperatorTokenType : OperatorTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.LeftArrow;
    }
}