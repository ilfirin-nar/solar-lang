using System.Collections.Generic;
using Solar.Domain.Grammar.GlobalStateObjects;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Domain.Grammar.Syntax
{
    public interface IForwardingRule<TToken> : IGlobalStateObject
        where TToken : ITokenType
    {
        IReadOnlyList<ITokenType> To { get; }
    }
}