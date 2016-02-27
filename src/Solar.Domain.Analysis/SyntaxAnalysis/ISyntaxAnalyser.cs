using System.Collections.Generic;
using Solar.Domain.Analysis.LexecalAnalysis.Entities;
using Solar.Domain.Analysis.SyntaxAnalysis.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.SyntaxAnalysis
{
    internal interface ISyntaxAnalyser : IDomainService
    {
        IAbstractSyntaxTree Analyse(IList<Token> tokens);
    }
}