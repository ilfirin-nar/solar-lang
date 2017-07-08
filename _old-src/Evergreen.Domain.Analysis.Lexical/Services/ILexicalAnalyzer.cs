using System.Collections.Generic;
using Evergreen.Domain.Grammar.Entities;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Analysis.Lexical.Services
{
    public interface ILexicalAnalyzer : IDomainService
    {
        IReadOnlyList<IToken> Analyze(string content);
    }
}