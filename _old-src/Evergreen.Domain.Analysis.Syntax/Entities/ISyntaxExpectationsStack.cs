using Evergreen.Domain.Grammar.Syntax.GlobalStateObjects.SyntaxExpectations;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Analysis.Syntax.Entities
{
    public interface ISyntaxExpectationsStack : IEntity
    {
        ISyntaxExpectation Pop();

        void Push(ISyntaxExpectation expectation);
    }
}