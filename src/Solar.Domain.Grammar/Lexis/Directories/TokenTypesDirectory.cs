using System.Collections.Generic;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;

namespace Solar.Domain.Grammar.Lexis.Directories
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