using System.Collections.Generic;
using Solar.Domain.Analysis.LexicalAnalysis.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis
{
    internal interface ILexicalAnalyzer : IDomainService
    {
        IList<Token> Analyse(string content);
    }
}