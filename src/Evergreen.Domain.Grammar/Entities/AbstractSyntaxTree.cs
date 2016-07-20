namespace Evergreen.Domain.Grammar.Entities
{
    internal class AbstractSyntaxTree : IAbstractSyntaxTree
    {
        public IToken Root { get; }

        public int NodesCount { get; }
    }
}