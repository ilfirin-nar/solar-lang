using Solar.Domain.Grammar.Syntax.GlobalStateObjects.SyntaxExpectations;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Syntax.Entities
{
    public interface ISyntaxExpectationsStack : IEntity
    {
        ISyntaxExpectation Pop();

        void Push(ISyntaxExpectation expectation);
    }
}