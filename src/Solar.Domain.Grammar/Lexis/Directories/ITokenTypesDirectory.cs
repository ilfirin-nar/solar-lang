using System.Collections.Generic;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Domain.Grammar.Lexis.Directories
{
    public interface ITokenTypesDirectory : IDirectory
    {
         IReadOnlyList<ITokenType> TokenTypes { get; } 
    }
}