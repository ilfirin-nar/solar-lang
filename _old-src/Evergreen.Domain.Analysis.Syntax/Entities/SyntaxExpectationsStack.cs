using System.Collections.Generic;
using Evergreen.Domain.Grammar.Syntax.GlobalStateObjects.SyntaxExpectations;

namespace Evergreen.Domain.Analysis.Syntax.Entities
{
    internal sealed class SyntaxExpectationsStack : Stack<ISyntaxExpectation>, ISyntaxExpectationsStack {}
}