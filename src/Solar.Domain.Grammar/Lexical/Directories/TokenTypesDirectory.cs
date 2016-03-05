using System.Collections.Generic;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;

namespace Solar.Domain.Grammar.Lexical.Directories
{
    internal class TokenTypesDirectory : ITokenTypesDirectory
    {
        public TokenTypesDirectory(IReadOnlyList<ITokenType> tokenTypes)
        {
            TokenTypes = tokenTypes;
        }

        public IReadOnlyList<ITokenType> TokenTypes { get; }
    }
}