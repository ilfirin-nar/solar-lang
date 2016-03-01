using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Identifiers
{
    public class TypeIdentifierTokenType : ITokenType
    {
        public Regex CharacteristicRegex => RegularExpressions.WordStartedWithCapitalChar;
    }
}