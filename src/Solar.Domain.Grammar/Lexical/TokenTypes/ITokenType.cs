using System.Text.RegularExpressions;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexical.TokenTypes
{
    public interface ITokenType : IValueObject
    {
        Regex CharacteristicRegex { get; }
    }
}