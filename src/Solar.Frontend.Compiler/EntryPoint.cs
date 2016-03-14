using LightInject;
using Solar.Frontend.Compiler.Program;

namespace Solar.Frontend.Compiler
{
    public static class EntryPoint
    {
        private static readonly ICompilerProgram CompilerProgram;

        static EntryPoint()
        {
            CompilerProgram = new ServiceContainer(new ContainerOptions { EnableVariance = false }).GetInstance<ICompilerProgram>();
        }

        public static void Main(string[] args)
        {
            CompilerProgram.Start(args);
        }
    }
}
