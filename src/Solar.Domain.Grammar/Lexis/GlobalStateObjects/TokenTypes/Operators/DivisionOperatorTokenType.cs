using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators
{
    public class DivisionOperatorTokenType : OperatorTokenTypeBase
    {
        protected  override Regex CharacteristicRegex => LexemesRegularExpressions.Division;
    }
}