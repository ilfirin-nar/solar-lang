using Evergreen.Domain.Analysis.Semantic.Entity;
using Evergreen.Domain.Grammar.Entities;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Analysis.Semantic.Services
{
    public interface ISemanticAnalyzer : IDomainService
    {
        ISemanticModel Analyze(IAbstractSyntaxTree abstractSyntaxTree);
    }
}