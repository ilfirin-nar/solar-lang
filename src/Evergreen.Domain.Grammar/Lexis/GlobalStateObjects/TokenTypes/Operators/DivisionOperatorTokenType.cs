using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators
{
    public class DivisionOperatorTokenType : OperatorTokenTypeBase
    {
        protected  override Regex CharacteristicRegex => LexemesRegularExpressions.Division;
    }
}