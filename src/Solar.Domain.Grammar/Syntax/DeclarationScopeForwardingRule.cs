using System.Collections.Generic;
using Solar.Domain.Grammar.GlobalStateObjects;
using Solar.Domain.Grammar.Syntax.GlobalStateObjects.TokenTypes.Statements;

namespace Solar.Domain.Grammar.Syntax
{
    public class DeclarationScopeForwardingRule : IForwardingRule<DeclarationScopeStatementTokenType>
    {
        public IReadOnlyList<ITokenType> To { get; }
    }
}