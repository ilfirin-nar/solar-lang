using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers
{
    public class TypeIdentifierTokenType : IdentifierTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.WordStartedWithCapitalChar;
    }
}