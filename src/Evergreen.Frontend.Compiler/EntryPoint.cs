using Evergreen.Frontend.Compiler.Program;
using Photosphere.DependencyInjection;

namespace Evergreen.Frontend.Compiler
{
    public static class EntryPoint
    {
        private static readonly CompilerProgram CompilerProgram;

        static EntryPoint()
        {
            CompilerProgram = new DependencyContainer().GetInstance<CompilerProgram>();
        }

        public static void Main(string[] args)
        {
            CompilerProgram.Start(args);
        }
    }
}
