using Solar.Application.Compiler.DataTransferObjects;
using Solar.Domain.Analysis.Lexical.Services;
using Solar.Domain.Analysis.Semantic.Services;
using Solar.Domain.Analysis.Syntax.Services;

namespace Solar.Application.Compiler.Services
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

        public void Compile(IModulesPathes modulesPathes)
        {
            throw new System.NotImplementedException();
        }
    }
}