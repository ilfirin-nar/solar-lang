using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Whitespaces
{
    public class IndentTokenType : ITokenType
    {
        public Regex CharacteristicRegex => RegularExpressions.Indent;
    }
}