using System.Collections.Generic;
using Evergreen.Domain.Grammar.Entities;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Analysis.Syntax.Services
{
    public interface ISyntaxAnalyzer : IDomainService
    {
        IAbstractSyntaxTree Analyze(IReadOnlyList<IToken> tokens);
    }
}