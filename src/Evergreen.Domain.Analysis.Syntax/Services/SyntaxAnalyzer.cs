using System.Collections.Generic;
using Evergreen.Domain.Grammar.Entities;

namespace Evergreen.Domain.Analysis.Syntax.Services
{
    internal class SyntaxAnalyzer : ISyntaxAnalyzer
    {
        public IAbstractSyntaxTree Analyze(IReadOnlyList<IToken> tokens)
        {
            foreach (var token in tokens)
            {
                
            }
            throw new System.NotImplementedException();
        }
    }
}