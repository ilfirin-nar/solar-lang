using LightInject;
using Solar.Frontend.Compiler.Services;

namespace Solar.Frontend.Compiler
{
    public static class EntryPoint
    {
        private static readonly ICompilerProgram CompilerProgram;

        static EntryPoint()
        {
            var container = new ServiceContainer();
            CompilerProgram = container.GetInstance<ICompilerProgram>();
        }

        public static void Main(string[] args)
        {
            CompilerProgram.Start(args);
        }
    }
}
