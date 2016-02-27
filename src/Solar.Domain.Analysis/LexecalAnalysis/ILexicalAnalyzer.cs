using System.Collections.Generic;
using Solar.Domain.Analysis.LexecalAnalysis.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexecalAnalysis
{
    internal interface ILexicalAnalyzer : IDomainService
    {
        IList<Token> Analyse(string content);
    }
}