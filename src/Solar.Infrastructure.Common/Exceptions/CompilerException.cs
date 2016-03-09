using System;

namespace Solar.Infrastructure.Common.Exceptions
{
    public class CompilerException : Exception
    {
        public override string Message => "Compiler exception";
    }
}