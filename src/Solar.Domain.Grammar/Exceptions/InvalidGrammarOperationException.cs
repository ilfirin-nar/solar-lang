namespace Solar.Domain.Grammar.Exceptions
{
    public class InvalidGrammarOperationException : GrammarException
    {
        public override string Message => "Invalid grammar operation";
    }
}