using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Identifiers
{
    public class LocalIdentifierTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemRegularExpressions.WordStartedWithNonCapitalChar;
    }
}