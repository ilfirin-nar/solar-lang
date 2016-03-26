using System;
using System.Collections.Generic;
using Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Domain.Grammar.Lexis.Directories
{
    public interface ILexicalTokenTypesDirectory : IDirectory
    {
        IReadOnlyList<ILexicalTokenType> LexicalTokenTypes { get; }

        TTokenType Get<TTokenType>() where TTokenType : ILexicalTokenType;

        ILexicalTokenType Get(Type type);
    }
}