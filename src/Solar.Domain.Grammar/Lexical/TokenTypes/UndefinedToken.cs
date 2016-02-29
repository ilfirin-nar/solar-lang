using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Exceptions;

namespace Solar.Domain.Grammar.Lexical.TokenTypes
{
    public class UndefinedToken : ITokenType
    {
        public Regex CharacteristicRegex
        {
            get { throw new InvalidGrammarOperationException(); }
        }
    }
}