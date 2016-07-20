using Evergreen.Frontend.Compiler.Program;
using LightInject;

namespace Evergreen.Frontend.Compiler
{
    public static class EntryPoint
    {
        private static readonly CompilerProgram CompilerProgram;

        static EntryPoint()
        {
            CompilerProgram = new ServiceContainer().GetInstance<CompilerProgram>();
        }

        public static void Main(string[] args)
        {
            CompilerProgram.Start(args);
        }
    }
}
