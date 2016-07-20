using System;
using System.Collections.Generic;
using System.Linq;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;

namespace Evergreen.Domain.Grammar.Lexis.Directories
{
    internal class LexicalTokenTypesDirectory : ILexicalTokenTypesDirectory
    {
        public LexicalTokenTypesDirectory(IReadOnlyList<ILexicalTokenType> tokenTypes)
        {
            LexicalTokenTypes = tokenTypes;
        }

        public IReadOnlyList<ILexicalTokenType> LexicalTokenTypes { get; }

        public TTokenType Get<TTokenType>() where TTokenType : ILexicalTokenType
        {
            return (TTokenType) LexicalTokenTypes.Single(t => t is TTokenType);
        }

        public ILexicalTokenType Get(Type type)
        {
            return LexicalTokenTypes.Single(t => t.GetType() == type);
        }
    }
}