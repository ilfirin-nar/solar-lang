using System;
using System.Collections.Generic;
using System.Linq;
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

        public TTokenType Get<TTokenType>() where TTokenType : ITokenType
        {
            return (TTokenType) TokenTypes.Single(t => t is TTokenType);
        }

        public ITokenType Get(Type type)
        {
            return TokenTypes.Single(t => t.GetType() == type);
        }
    }
}