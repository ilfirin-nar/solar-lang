using System.Collections.Generic;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical
{
    internal interface ILexicalAnalyzer : IDomainService
    {
        IReadOnlyList<Token> Analyse(string content);
    }
}