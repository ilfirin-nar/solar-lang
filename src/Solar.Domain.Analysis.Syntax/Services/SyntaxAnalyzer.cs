using System.Collections.Generic;
using Solar.Domain.Grammar.Entities;

namespace Solar.Domain.Analysis.Syntax.Services
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