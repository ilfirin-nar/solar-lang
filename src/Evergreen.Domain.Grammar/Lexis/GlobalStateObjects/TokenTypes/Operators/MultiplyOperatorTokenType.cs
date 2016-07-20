using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators
{
    public class MultiplyOperatorTokenType : OperatorTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.Multiply;
    }
}