using System.Collections.Generic;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Domain.Grammar.Lexical.Directories
{
    public interface ITokenTypesDirectory : IDirectory
    {
         IReadOnlyList<ITokenType> TokenTypes { get; } 
    }
}