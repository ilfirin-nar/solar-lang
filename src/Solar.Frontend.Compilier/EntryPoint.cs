using LightInject;
using Solar.Frontend.Compiler.Services;

namespace Solar.Frontend.Compiler
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
