using System.Collections.Generic;
using Solar.Domain.Analysis.Lexical.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical
{
    internal interface ILexicalAnalyzer : IDomainService
    {
        IList<Token> Analyse(string content);
    }
}