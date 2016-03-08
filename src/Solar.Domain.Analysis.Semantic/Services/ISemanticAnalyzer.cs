using Solar.Domain.Analysis.Semantic.Entity;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Semantic.Services
{
    public interface ISemanticAnalyzer : IDomainService
    {
        ISemanticModel Analyze(IAbstractSyntaxTree abstractSyntaxTree);
    }
}