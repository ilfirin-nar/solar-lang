using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers
{
    public class TypeIdentifierTokenType : IdentifierTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.WordStartedWithCapitalChar;
    }
}