using Evergreen.Application.Compiler.DataTransferObjects;
using Evergreen.Domain.Analysis.Lexical.Services;
using Evergreen.Domain.Analysis.Semantic.Services;
using Evergreen.Domain.Analysis.Syntax.Services;

namespace Evergreen.Application.Compiler.Services
{
    internal class Compiler : ICompiler
    {
        private readonly ILexicalAnalyzer _lexicalAnalyzer;
        private readonly ISyntaxAnalyzer _syntaxAnalyzer;
        private readonly ISemanticAnalyzer _semanticAnalyzer;

        public Compiler(
            ILexicalAnalyzer lexicalAnalyzer,
            ISyntaxAnalyzer syntaxAnalyzer,
            ISemanticAnalyzer semanticAnalyzer)
        {
            _lexicalAnalyzer = lexicalAnalyzer;
            _syntaxAnalyzer = syntaxAnalyzer;
            _semanticAnalyzer = semanticAnalyzer;
        }

        public void Compile(ModulesPathes modulesPathes)
        {
        }
    }
}