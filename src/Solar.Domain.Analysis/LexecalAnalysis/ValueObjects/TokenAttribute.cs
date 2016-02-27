using Solar.Domain.Grammar.Enums;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexecalAnalysis.ValueObjects
{
    internal class TokenAttribute : IValueObject
    {
         public TokenType Type { get; set; }
    }
}