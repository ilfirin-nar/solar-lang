using System.Collections.Generic;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical.Services
{
    public interface ILexicalAnalyzer : IDomainService
    {
        IReadOnlyList<IToken> Analyze(string content);
    }
}