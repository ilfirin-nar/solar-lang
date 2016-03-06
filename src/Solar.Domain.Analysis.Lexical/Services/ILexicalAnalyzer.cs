using System.Collections.Generic;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical.Services
{
    internal interface ILexicalAnalyzer : IDomainService
    {
        IReadOnlyList<Token> Analyze(string content);
    }
}