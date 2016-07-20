using System;
using System.Collections.Generic;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
using Evergreen.Infrastructure.Common.Interfaces;

namespace Evergreen.Domain.Grammar.Lexis.Directories
{
    public interface ILexicalTokenTypesDirectory : IDirectory
    {
        IReadOnlyList<ILexicalTokenType> LexicalTokenTypes { get; }

        TTokenType Get<TTokenType>() where TTokenType : ILexicalTokenType;

        ILexicalTokenType Get(Type type);
    }
}