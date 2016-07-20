using Evergreen.Frontend.Compiler.Program;
using LightInject;

namespace Evergreen.Frontend.Compiler
{
    public static class EntryPoint
    {
        private static readonly ICompilerProgram CompilerProgram;

        static EntryPoint()
        {
            CompilerProgram = new ServiceContainer().GetInstance<ICompilerProgram>();
        }

        public static void Main(string[] args)
        {
            CompilerProgram.Start(args);
        }
    }
}
