using System.Collections.Generic;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Syntax.Services
{
    public interface ISyntaxAnalyzer : IDomainService
    {
        IAbstractSyntaxTree Analyze(IReadOnlyList<IToken> tokens);
    }
}