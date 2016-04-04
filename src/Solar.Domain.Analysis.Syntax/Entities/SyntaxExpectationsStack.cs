using System.Collections.Generic;
using Solar.Domain.Grammar.Syntax.GlobalStateObjects.SyntaxExpectations;

namespace Solar.Domain.Analysis.Syntax.Entities
{
    internal sealed class SyntaxExpectationsStack : Stack<ISyntaxExpectation>, ISyntaxExpectationsStack {}
}