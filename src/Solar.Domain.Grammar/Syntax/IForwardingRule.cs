using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.Syntax.GlobalStateObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Domain.Grammar.Syntax
{
    public interface IForwardingRule<TToken> : IGlobalStateObject
        where TToken : ISyntaxTokenType
    {
        bool IsForwarding(IToken token);
    }
}