using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.Syntax.GlobalStateObjects.TokenTypes.Statements;

namespace Solar.Domain.Grammar.Syntax
{
    public class DeclarationScopeForwardingRule : IForwardingRule<DeclarationScopeStatementTokenType>
    {
        public bool IsForwarding(IToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}